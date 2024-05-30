using NutritionalRecipeBook.Domain.ValueObjects;

namespace NutritionalRecipeBook.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; } 

        public string Description { get; set; } 

        public double Calories { get; set; } 

        public List<RecipeIngredient> Ingredients { get; set; }

        public double? Votes { get; set; }

        public bool? IsPremium { get; set; }
        
        public bool? IsCreatedByUser { get; set; }

        public Recipe() { }

        public Recipe(RecipeSpecification specification)
        {
            Name = specification.Name;
            Description = specification.Description;
            Calories = specification.Calories;
        }
    } 
}
