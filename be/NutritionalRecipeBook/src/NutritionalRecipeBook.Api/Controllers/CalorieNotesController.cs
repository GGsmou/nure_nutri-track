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
            CreatedAt = request.CreatedAt,
            UserId = request.UserId
        };
        
        await _calorieNoteRepository.CreateAsync(calorieNote);

        return Ok(calorieNote);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AddCalorieNoteRequest calorieNote)
    {
        var existingCalorieNote = await _calorieNoteRepository.GetByIdAsync((Guid)calorieNote.Id!);

        if (existingCalorieNote == null) return NotFound();

        existingCalorieNote.Calorie = calorieNote.Calorie;
        existingCalorieNote.CreatedAt = calorieNote.CreatedAt;
        existingCalorieNote.UserId = calorieNote.UserId;
        
        await _calorieNoteRepository.UpdateAsync(existingCalorieNote);

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