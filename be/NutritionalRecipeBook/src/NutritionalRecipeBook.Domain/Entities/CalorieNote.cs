namespace NutritionalRecipeBook.Domain.Entities;

public class CalorieNote : BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public decimal Calorie { get; set; }
}