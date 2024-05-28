namespace NutritionalRecipeBook.Domain.Entities;

public class UserHydration : BaseEntity
{
    public Guid HydrationId { get; set; }

    public Hydration Hydration { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }
}