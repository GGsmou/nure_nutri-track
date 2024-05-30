using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NutritionalRecipeBook.Application.Common.Collections;
using NutritionalRecipeBook.Application.Common.Models;
using NutritionalRecipeBook.Application.Common.Models.Recipe;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Domain.Results;
using NutritionalRecipeBook.Domain.ValueObjects;
using NutritionalRecipeBook.Infrastructure.Contracts;
namespace NutritionalRecipeBook.Application.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IGenericRepository<Ingredient> _ingredientRepository;

        private readonly IRecipeRepository _recipeRepository;

        private readonly IGenericRepository<RecipeIngredient> _recipeIngredientRepository;

        private readonly IGenericRepository<Category> _categoryRepository;

        private readonly INutritionService _nutritionService;

        private readonly IMapper _mapper;

        private readonly IIdentityService _identityService;

        public RecipeService(IGenericRepository<Ingredient> ingredientRepository,
            IRecipeRepository recipeRepository,
            IGenericRepository<RecipeIngredient> recipeIngredientRepository,
            IGenericRepository<Category> categoryRepository,
            INutritionService nutritionService,
            IMapper mapper,
            IIdentityService identityService
            )
        {
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
            _categoryRepository = categoryRepository;
            _nutritionService = nutritionService;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<Result<PagedList<GetRecipeResponse>>> GetAllAsync(SearchParams parameters)
        {
            var recipes = await _recipeRepository.GetAllSearchedAsync(parameters);
            var mappedRecipes = new PagedList<GetRecipeResponse>(_mapper.Map<List<GetRecipeResponse>>(recipes), recipes.TotalCount, recipes.CurrentPage, recipes.PageSize);

            return Result<PagedList<GetRecipeResponse>>.Success(mappedRecipes);
        }

        public async Task<Result<Recipe>> GetByIdAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);

            if (recipe != null)
            {
                return Result<Recipe>.Success(recipe);
            }

            return Result<Recipe>.Failure(new Error("404", "Such recipe doesn't exist."));
        }

        public async Task<Result<GetRecipeResponse>> GetByIdWithRelationsAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetByIdWithRelationsAsync(id);

            if (recipe is null)
            {
                return Result<GetRecipeResponse>.Failure(new Error("404", "Such recipe doesn't exist."));
            }

            var response = _mapper.Map<GetRecipeResponse>(recipe);

            return Result<GetRecipeResponse>.Success(response);
        }

        public async Task<Result> CreateAsync(CreateRecipeRequest request)
        {
            var recipeSpecification = new RecipeSpecification(request.Name, request.Description, request.Calories);

            var recipe = new Recipe(recipeSpecification, request.UserId);

            await _recipeRepository.CreateAsync(recipe);
            await AddIngredients(recipe, request);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(UpdateRecipeRequest request)
        {
            var user = await _identityService.FindUserByIdAsync(request.UserId);

            if (user is null)
            {
                return Result.Failure(new Error("404", "Such user doesn't exist"));
            }

            var existingRecipe = await _recipeRepository.GetByIdWithRelationsAsync(request.Id);

            if (existingRecipe is null)
            {
                return Result.Failure(new Error("404", "Such recipe doesn't exist"));
            }

            if (existingRecipe.UserId == user.Id)
            {
                await UpdatePlainProperties(existingRecipe, request);
                await UpdateIngredients(existingRecipe, request);
                await _recipeRepository.UpdateAsync(existingRecipe);

                return Result.Success();
            }

            return Result.Failure(new Error("403", "Recipes can be updated only by creator"));
        }

        public async Task<Result> DeleteByIdAsync(Guid id, string userId)
        {
            var user = await _identityService.FindUserByIdAsync(userId);

            if (user is null)
            {
                return Result.Failure(new Error("404", "Such user doesn't exist"));
            }

            var recipeToDelete = await _recipeRepository.GetByIdAsync(id);

            if (recipeToDelete is null)
            {
                return Result.Failure(new Error("404", "Such recipe doesn't exist."));
            }

            if (recipeToDelete.UserId == user.Id)
            {
                await _recipeRepository.RemoveByIdAsync(recipeToDelete.Id);

                return Result.Success();
            }

            return Result.Failure(new Error("403", "Recipes can be deleted only by creator"));
        }

        private async Task AddIngredients(Recipe recipe, CreateRecipeRequest request)
        {
            foreach (var ingredientId in request.NewIngredientIds)
            {
                var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);
                
                if (ingredient == null) continue;

                var recipeIngredient = new RecipeIngredient()
                {
                    IngredientId = ingredientId,
                    RecipeId = recipe.Id
                };

                await _recipeIngredientRepository.CreateAsync(recipeIngredient);
            }
        }

        private async Task UpdateIngredients(Recipe recipeToUpdate, UpdateRecipeRequest request)
        {
            var existingIngredientsIds = request.ExistingIngredients
                .Select(i => i.Id);

            var updatedIngredients = await _recipeIngredientRepository
                .GetManyByPredicateAsync(ri => existingIngredientsIds
                .Contains(ri.IngredientId) && ri.RecipeId == recipeToUpdate.Id);

            recipeToUpdate.Ingredients = updatedIngredients;

            foreach (var newIngredient in request.NewIngredients)
            {
                newIngredient.Id = Guid.NewGuid();
            }

            await _ingredientRepository.CreateManyAsync(request.NewIngredients);

            var ingredientsToAdd = new List<RecipeIngredient>();

            foreach (var ingredient in request.NewIngredients)
            {
                ingredientsToAdd.Add(new RecipeIngredient { Recipe = recipeToUpdate, Ingredient = ingredient });
            }

            await _recipeIngredientRepository.CreateManyAsync(ingredientsToAdd);
        }

        private async Task UpdatePlainProperties(Recipe recipeToUpdate, UpdateRecipeRequest request)
        {
            recipeToUpdate.Name = request.Name;
            recipeToUpdate.Description = request.Description;
            recipeToUpdate.Calories = request.Calories;
        }
    }
}
