using NutritionalRecipeBook.Domain.Entities;

namespace NutritionalRecipeBook.Application.Common.Models;

public class CreateUserTypeRequest
{
    public Guid Id { get; set; }
    
    public string UserId { get; set; }
    
    public string Name { get; set; }
    
    public Role Role { get; set; }
    
    public Subscription Subscription { get; set; }

    public List<Guid> BannedIngredientIds { get; set; }
    
    public int DailyCalories { get; set; }
    
    public double Weight { get; set; }
    
    public double DesiredWeight { get; set; }
    
    public bool Hydrated { get; set; }
    
    public bool Exercised { get; set; }
    
    public bool AteHealthy { get; set; }
    
    public bool Chef { get; set; }
    
    public bool Critic { get; set; }
    
    public bool CriticTwoPointO { get; set; }
    
    public bool Social { get; set; }
}