

namespace NutritionalRecipeBook.Domain.ValueObjects
{
    public class RecipeSpecification
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Calories { get; set; }

        public RecipeSpecification(string name, string description, double calories)
        {
            Name = name;
            Description = description;
            Calories = calories;
        }
    }
}
