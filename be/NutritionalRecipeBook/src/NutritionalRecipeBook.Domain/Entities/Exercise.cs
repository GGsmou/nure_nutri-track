namespace NutritionalRecipeBook.Domain.Entities;

public class Exercise : BaseEntity
{
    public string Name { get; set; } 
    
    public double Calories { get; set; } 
    
    public string Description { get; set; } 
}