using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NutritionalRecipeBook.Application.Common.Models;
using NutritionalRecipeBook.Application.Common.Models.Recipe;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Domain.Enums;
using NutritionalRecipeBook.Infrastructure.Contracts;


namespace NutritionalRecipeBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        
        private readonly IGenericRepository<Recipe> _recipeRepository;

        private readonly IValidator<CreateRecipeRequest> _createRecipeValidator;

        private readonly IValidator<UpdateRecipeRequest> _updateRecipeValidator;

        private readonly IValidator<SearchParams> _searchParamsValidator;

        public RecipesController(IRecipeService recipeService,
            IGenericRepository<Recipe> recipeRepository,
            IValidator<UpdateRecipeRequest> updateRecipeValidator,
            IValidator<CreateRecipeRequest> createRecipeValidator,
            IValidator<SearchParams> searchParamsValidator)
        {
            _recipeService = recipeService;
            _recipeRepository = recipeRepository;
            _createRecipeValidator = createRecipeValidator;
            _updateRecipeValidator = updateRecipeValidator;
            _searchParamsValidator = searchParamsValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SearchParams parameters)
        {
            var result = await _recipeService.GetAllAsync(parameters);

            if (result.IsSuccess)
            {
                var recipes = result.Value;

                var metadata = new
                {
                    recipes.TotalCount,
                    recipes.PageSize,
                    recipes.CurrentPage,
                    recipes.TotalPages,
                    recipes.HasNext,
                    recipes.HasPrevious
                };

                Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));
                Response.Headers.Append("Access-Control-Expose-Headers", "X-Pagination");
            }

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _recipeService.GetByIdWithRelationsAsync(id);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRecipeRequest request)
        {
            var result = await _recipeService.CreateAsync(request);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRecipeRequest request)
        {
            var result = await _recipeService.UpdateAsync(request);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, [FromQuery] string userId)
        {
            var result = await _recipeService.DeleteByIdAsync(id, userId);

            return result.IsSuccess ? Ok($"Recipe with id ({id}) deleted") : BadRequest(result.Error.Message);
        }
        
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] VoteType voteType)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);

            if (recipe == null) return NotFound();

            recipe.Votes ??= 0;
                
            switch (voteType)
            {
                case VoteType.Up:
                    recipe.Votes++;
                    break;
                case VoteType.Down:
                    recipe.Votes--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            await _recipeRepository.UpdateAsync(recipe);

            return Ok(recipe);
        }
    }
}
