using Microsoft.AspNetCore.Mvc;
using NutritionalRecipeBook.Application.Common.Models;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Infrastructure.Contracts;

namespace NutritionalRecipeBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExercisesNotesController : Controller
{
    private readonly IGenericRepository<ExercisesNote> _exerciseNoteRepository;
    private readonly IIdentityService _identityService;
    private readonly IGenericRepository<Exercise> _exerciseRepository;

    public ExercisesNotesController(IGenericRepository<ExercisesNote> exerciseNoteRepository, IIdentityService identityService, IGenericRepository<Exercise> exerciseRepository)
    {
        _exerciseNoteRepository = exerciseNoteRepository;
        _identityService = identityService;
        _exerciseRepository = exerciseRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _exerciseNoteRepository.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _exerciseNoteRepository.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddExerciseNoteRequest exercisesNote)
    {
        var user = await _identityService.GetUserByIdWithRelationsAsync(exercisesNote.UserId);
        var exercise = await _exerciseRepository.GetByIdAsync(exercisesNote.ExerciseId);
        
        var result = new ExercisesNote()
        {
            ExerciseId = exercisesNote.ExerciseId,
            UserId = exercisesNote.UserId,
            Calories = exercisesNote.Calories,
            User = user,
            Exercise = exercise
        };
        
        await _exerciseNoteRepository.CreateAsync(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ExercisesNote exercisesNote)
    { 
        await _exerciseNoteRepository.UpdateAsync(exercisesNote);

        return Ok(exercisesNote);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultForDeleting = await _exerciseNoteRepository.GetByIdAsync(id);
        if (resultForDeleting == null) return NotFound();
            
        await _exerciseNoteRepository.RemoveAsync(resultForDeleting);

        return Ok($"({id}) deleted");
    }
}