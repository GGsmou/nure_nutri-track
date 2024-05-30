namespace NutritionalRecipeBook.Domain.Entities;

public class WaterNote : BaseEntity
{
    public User User { get; set; }

    public string UserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public double Ml { get; set; }
}