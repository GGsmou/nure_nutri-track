namespace NutritionalRecipeBook.Domain.Entities;

public class UserTypeIngredient : BaseEntity
{
    public Guid UserTypeId { get; set; }

    public UserType UserType { get; set; }

    public Guid IngredientId { get; set; }

    public Ingredient Ingredient { get; set; }
}