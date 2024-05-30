namespace NutritionalRecipeBook.Application.Common.Models;

public class AddWaterCommentRequest
{
    public Guid? Id { get; set; }
    
    public string UserId { get; set; }

    public double Ml { get; set; }
    
    public DateTime CreatedAt { get; set; }
}