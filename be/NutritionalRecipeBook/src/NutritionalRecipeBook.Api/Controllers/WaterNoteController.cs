using Microsoft.AspNetCore.Mvc;
using NutritionalRecipeBook.Application.Common;
using NutritionalRecipeBook.Application.Common.Models;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Infrastructure.Contracts;

namespace NutritionalRecipeBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WaterNoteController : Controller
{
    private readonly IGenericRepository<WaterNote> _waterNoteRepository;

    public WaterNoteController(IGenericRepository<WaterNote> waterNoteRepository)
    {
        _waterNoteRepository = waterNoteRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _waterNoteRepository.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _waterNoteRepository.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddWaterCommentRequest request)
    {
        var result = new WaterNote()
        {
            UserId = request.UserId,
            Ml = request.Ml,
            CreatedAt = request.CreatedAt
        };
        
        await _waterNoteRepository.CreateAsync(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AddWaterCommentRequest request)
    { 
        var result = new WaterNote()
        {
            UserId = request.UserId,
            Ml = request.Ml,
            CreatedAt = request.CreatedAt,
            Id = (Guid)request.Id!
        };
        
        await _waterNoteRepository.UpdateAsync(result);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultForDeleting = await _waterNoteRepository.GetByIdAsync(id);
        if (resultForDeleting == null) return NotFound();
            
        await _waterNoteRepository.RemoveAsync(resultForDeleting);

        return Ok($"({id}) deleted");
    }
}