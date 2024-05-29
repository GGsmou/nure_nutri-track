using Microsoft.AspNetCore.Mvc;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Infrastructure.Contracts;

namespace NutritionalRecipeBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HydrationsController : Controller
{
    private readonly IGenericRepository<Hydration> _hydrationRepository;
    private readonly IIdentityService _identityService;
    private readonly IGenericRepository<UserHydration> _userHydrationRepository;

    public HydrationsController(IGenericRepository<Hydration> hydrationRepository, IIdentityService identityService, IGenericRepository<UserHydration> userHydrationRepository)
    {
        _hydrationRepository = hydrationRepository;
        _identityService = identityService;
        _userHydrationRepository = userHydrationRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _hydrationRepository.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _hydrationRepository.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> Create([FromBody] Hydration hydration, [FromRoute] Guid userId)
    {
        await _hydrationRepository.CreateAsync(hydration);
    
        var user = await _identityService.GetUserByIdWithRelationsAsync(userId.ToString());

        if (user == null) return Ok(hydration);
    
        var userHydration = new UserHydration()
        {
            HydrationId = hydration.Id,
            UserId = userId.ToString()
        };

        await _userHydrationRepository.CreateAsync(userHydration);

        return Ok(userHydration);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Hydration hydration)
    { 
        await _hydrationRepository.UpdateAsync(hydration);

        return Ok(hydration);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultForDeleting = await _hydrationRepository.GetByIdAsync(id);
        await _hydrationRepository.RemoveAsync(resultForDeleting);

        return Ok($"({id}) deleted");
    }
}