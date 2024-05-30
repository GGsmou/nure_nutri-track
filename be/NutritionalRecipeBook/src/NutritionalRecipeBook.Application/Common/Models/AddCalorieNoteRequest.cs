namespace NutritionalRecipeBook.Application.Common.Models;

public class AddCalorieNoteRequest
{
    public Guid? Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public decimal Calorie { get; set; }

    public string UserId { get; set; }
    
    public Guid RecipeId { get; set; }
}