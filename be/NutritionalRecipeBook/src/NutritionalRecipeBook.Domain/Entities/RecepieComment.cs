namespace NutritionalRecipeBook.Domain.Entities;

public class RecipeComment : BaseEntity
{
    public string UserId { get; set; }

    public Guid RecipeId { get; set; }

    public User User { get; set; }

    public Recipe Recipe { get; set; }

    public string Comment { get; set; }
}