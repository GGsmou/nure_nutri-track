namespace NutritionalRecipeBook.Domain.Entities;

public class ExercisesNote : BaseEntity
{
    public User User { get; set; }

    public string UserId { get; set; }
    
    public Exercise Exercise { get; set; }

    public Guid ExerciseId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public double Calories { get; set; } 
}