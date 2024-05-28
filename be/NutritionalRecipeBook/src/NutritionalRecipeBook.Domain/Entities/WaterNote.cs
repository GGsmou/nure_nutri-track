namespace NutritionalRecipeBook.Domain.Entities;

public class WaterNote : BaseEntity
{
    public User User { get; set; }

    public string UserId { get; set; }

    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    public double Ml { get; set; }
}