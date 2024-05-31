namespace NutritionalRecipeBook.Application.Common.Models;

public class AddCalorieNoteRequest
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public decimal Calorie { get; set; }

    public string UserId { get; set; }
    
    public Guid? Id { get; set; }
}