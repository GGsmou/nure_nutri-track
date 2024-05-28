namespace NutritionalRecipeBook.Domain.Entities;

public class CalorieNote : BaseEntity
{
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public decimal Calorie { get; set; }
}