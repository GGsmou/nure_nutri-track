namespace NutritionalRecipeBook.Application.Common.Models;

public class AddExerciseNoteRequest
{
    public Guid? Id { get; set; }
    
    public string UserId { get; set; }
    
    public Guid ExerciseId { get; set; }
    
    public double Calories { get; set; } 
    
    public DateTime CreatedAt { get; set; }
}