namespace NutritionalRecipeBook.Application.Common;

public class AddRecipeCommentRequest
{
    public string UserId { get; set; }

    public Guid RecipeId { get; set; }

    public string Comment { get; set; }
}