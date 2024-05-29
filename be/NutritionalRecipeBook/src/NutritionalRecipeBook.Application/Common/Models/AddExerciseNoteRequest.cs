namespace NutritionalRecipeBook.Application.Common.Models;

public class AddExerciseNoteRequest
{
    public string UserId { get; set; }
    public Guid ExerciseId { get; set; }
    public double Calories { get; set; } 
}