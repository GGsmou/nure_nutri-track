using Microsoft.AspNetCore.Mvc;
using NutritionalRecipeBook.Application.Common;
using NutritionalRecipeBook.Application.Common.Models;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Infrastructure.Contracts;

namespace NutritionalRecipeBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeCommentController : Controller
{
    private readonly IGenericRepository<Recipe> _recipeRepository;
    private readonly IIdentityService _identityService;
    private readonly IGenericRepository<RecipeComment> _recipeCommentRepository;

    public RecipeCommentController(IGenericRepository<Recipe> recipeRepository, IIdentityService identityService, IGenericRepository<RecipeComment> recipeCommentRepository)
    {
        _recipeRepository = recipeRepository;
        _identityService = identityService;
        _recipeCommentRepository = recipeCommentRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _recipeCommentRepository.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _recipeCommentRepository.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddRecipeCommentRequest request)
    {
        var result = new RecipeComment()
        {
            RecipeId = request.RecipeId,
            UserId = request.UserId,
            Comment = request.Comment,
        };
        
        await _recipeCommentRepository.CreateAsync(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RecipeComment recipeComment)
    { 
        await _recipeCommentRepository.UpdateAsync(recipeComment);

        return Ok(recipeComment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultForDeleting = await _recipeCommentRepository.GetByIdAsync(id);
        if (resultForDeleting == null) return NotFound();
            
        await _recipeCommentRepository.RemoveAsync(resultForDeleting);

        return Ok($"({id}) deleted");
    }
}