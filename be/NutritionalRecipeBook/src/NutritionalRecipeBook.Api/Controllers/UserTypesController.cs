using Microsoft.AspNetCore.Mvc;
using NutritionalRecipeBook.Application.Common.Models;
using NutritionalRecipeBook.Application.Contracts;
using NutritionalRecipeBook.Domain.Entities;
using NutritionalRecipeBook.Infrastructure.Contracts;

namespace NutritionalRecipeBook.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserTypesController : ControllerBase
{
    private readonly IGenericRepository<UserType> _userTypeRepository;
    private readonly IIdentityService _identityService;
    private readonly IGenericRepository<UserTypeIngredient> _userTypeIngredientRepository;

    public UserTypesController(
        IGenericRepository<UserType> userTypeRepository, 
        IIdentityService identityService, 
        IGenericRepository<UserTypeIngredient> userTypeIngredientRepository)
    {
        _userTypeRepository = userTypeRepository;
        _identityService = identityService;
        _userTypeIngredientRepository = userTypeIngredientRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userTypeRepository.GetAllAsync();

        foreach (var userType in result)
        {
            var banIngredients =
                await _userTypeIngredientRepository.GetManyByPredicateAsync(uti => uti.UserTypeId == userType.Id);

            userType.BannedIngredients = banIngredients;
        }
        
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _userTypeRepository.GetByIdAsync(id);

        if (result == null) return NotFound();
            
        var banIngredients =
            await _userTypeIngredientRepository.GetManyByPredicateAsync(uti => uti.UserTypeId == result.Id);

        result.BannedIngredients = banIngredients;
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserTypeRequest request)
    {
        var userType = new UserType()
        {
            UserId = request.UserId,
            Name = request.Name,
            Role = request.Role,
            Subscription = request.Subscription,
            DailyCalories = request.DailyCalories,
            Weight = request.Weight,
            DesiredWeight = request.DesiredWeight,
            Hydrated = request.Hydrated,
            Exercised = request.Exercised,
            AteHealthy = request.AteHealthy,
            Chef = request.Chef,
            Critic = request.Critic,
            CriticTwoPointO = request.CriticTwoPointO,
            Social = request.Social,
        };
        
        await _userTypeRepository.CreateAsync(userType);
        
        foreach (var bannedIngredientId in request.BannedIngredientIds)
        {
            var userBannedIngredient = new UserTypeIngredient()
            {
                UserTypeId = userType.Id,
                IngredientId = bannedIngredientId
            };

            await _userTypeIngredientRepository.CreateAsync(userBannedIngredient);
        }

        return Ok(userType);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateUserTypeRequest request)
    {
        var userType = await _userTypeRepository.GetByIdAsync(request.Id);

        if (userType == null) return NotFound();
        
        userType.UserId = request.UserId;
        userType.Name = request.Name;
        userType.Role = request.Role;
        userType.Subscription = request.Subscription;
        userType.DailyCalories = request.DailyCalories;
        userType.Weight = request.Weight;
        userType.DesiredWeight = request.DesiredWeight;
        userType.Hydrated = request.Hydrated;
        userType.Exercised = request.Exercised;
        userType.AteHealthy = request.AteHealthy;
        userType.Chef = request.Chef;
        userType.Critic = request.Critic;
        userType.CriticTwoPointO = request.CriticTwoPointO;
        userType.Social = request.Social;
        
        await _userTypeRepository.UpdateAsync(userType);
        
        foreach (var bannedIngredientId in request.BannedIngredientIds)
        {
            var userBannedIngredient = new UserTypeIngredient()
            {
                UserTypeId = userType.Id,
                IngredientId = bannedIngredientId
            };

            await _userTypeIngredientRepository.CreateAsync(userBannedIngredient);
        }

        return Ok(userType);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var resultForDeleting = await _userTypeRepository.GetByIdAsync(id);
        if (resultForDeleting == null) return NotFound();
            
        await _userTypeRepository.RemoveAsync(resultForDeleting);

        return Ok($"({id}) deleted");
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(Guid id, [FromBody] string name)
    {
        var userType = await _userTypeRepository.GetByIdAsync(id);

        if (userType == null) return NotFound();
        
        var property = typeof(UserType).GetProperties()
            .FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));

        if (property == null || property.PropertyType != typeof(bool))
        {
            return BadRequest("Invalid property name or property is not of type bool.");
        }

        property.SetValue(userType, true);
        
        await _userTypeRepository.UpdateAsync(userType);
        
        return Ok(userType);
    }
}