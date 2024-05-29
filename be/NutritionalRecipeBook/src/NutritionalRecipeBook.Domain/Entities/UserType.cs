namespace NutritionalRecipeBook.Domain.Entities;

public class UserType : BaseEntity
{
    public User User { get; set; }

    public string UserId { get; set; }
    
    public string Name { get; set; }
    
    public Role Role { get; set; }
    
    public Subscription Subscription { get; set; }

    public List<UserTypeIngredient> BannedIngredients { get; set; }
    
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

public enum Role
{
    Admin,
    User
}

public enum Subscription
{
    T1,
    T2,
    T3
}