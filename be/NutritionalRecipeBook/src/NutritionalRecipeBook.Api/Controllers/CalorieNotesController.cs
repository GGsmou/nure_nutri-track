using Microsoft.AspNetCore.Mvc;
using NutritionalRecipeBook.Application.Common.Models;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Infrastructure.Contracts;

namespace NutritionalRecipeBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CalorieNotesController : ControllerBase
{
    private readonly IGenericRepository<CalorieNote> _calorieNoteRepository;
    private readonly IIdentityService _identityService;
    private readonly IGenericRepository<UserRecipe> _userRecipeRepository;

    public CalorieNotesController(IGenericRepository<CalorieNote> calorieNoteRepository, IIdentityService identityService, IGenericRepository<UserRecipe> userRecipeRepository)
    {
        _calorieNoteRepository = calorieNoteRepository;
        _identityService = identityService;
        _userRecipeRepository = userRecipeRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _calorieNoteRepository.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _calorieNoteRepository.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddCalorieNoteRequest request)
    {
        var calorieNote = new CalorieNote()
        {
            Calorie = request.Calorie,
            CreatedAt = request.CreatedAt
        };
        
        await _calorieNoteRepository.CreateAsync(calorieNote);
    
        var user = await _identityService.GetUserByIdWithRelationsAsync(request.UserId);

        if (user == null) return NotFound();

        var userRecipe = new UserRecipe()
        {
            UserId = request.UserId,
            RecipeId = request.RecipeId,
            CCalorieNoteId = calorieNote.Id
        };
        
        await _userRecipeRepository.CreateAsync(userRecipe);

        return Ok(userRecipe);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AddCalorieNoteRequest calorieNote)
    {
        var existingCalorieNote = await _calorieNoteRepository.GetByIdAsync((Guid)calorieNote.Id!);

        if (existingCalorieNote == null) return NotFound();

        existingCalorieNote.CreatedAt = calorieNote.CreatedAt;
        existingCalorieNote.Calorie = calorieNote.Calorie;
        
        await _calorieNoteRepository.UpdateAsync(existingCalorieNote);
        
        var user = await _identityService.GetUserByIdWithRelationsAsync(calorieNote.UserId);

        if (user == null) return NotFound();

        var userRecipe = new UserRecipe()
        {
            UserId = calorieNote.UserId,
            RecipeId = calorieNote.RecipeId,
            CCalorieNoteId = calorieNote.Id
        };
        
        await _userRecipeRepository.CreateAsync(userRecipe);

        return Ok(calorieNote);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultForDeleting = await _calorieNoteRepository.GetByIdAsync(id);
        
        if (resultForDeleting == null) return NotFound();
        
        await _calorieNoteRepository.RemoveAsync(resultForDeleting);

        return Ok($"({id}) deleted");
    }
}