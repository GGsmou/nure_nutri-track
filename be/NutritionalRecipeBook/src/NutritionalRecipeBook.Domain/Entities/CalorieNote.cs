namespace NutritionalRecipeBook.Domain.Entities;

public class CalorieNote : BaseEntity
{
    public User? User { get; set; }

    public string? UserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public decimal Calorie { get; set; }
}