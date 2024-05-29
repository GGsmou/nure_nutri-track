using Microsoft.AspNetCore.Mvc;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Infrastructure.Contracts;

namespace NutritionalRecipeBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExercisesController : Controller
{
    private readonly IGenericRepository<Exercise> _exerciseRepository;
    private readonly IIdentityService _identityService;

    public ExercisesController(IGenericRepository<Exercise> exerciseRepository, IIdentityService identityService)
    {
        _exerciseRepository = exerciseRepository;
        _identityService = identityService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _exerciseRepository.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _exerciseRepository.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Exercise exercise)
    {
        await _exerciseRepository.CreateAsync(exercise);

        return Ok(exercise);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Exercise exercise)
    { 
        await _exerciseRepository.UpdateAsync(exercise);

        return Ok(exercise);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultForDeleting = await _exerciseRepository.GetByIdAsync(id);
        if (resultForDeleting == null) return NotFound();
            
        await _exerciseRepository.RemoveAsync(resultForDeleting);

        return Ok($"({id}) deleted");
    }
}