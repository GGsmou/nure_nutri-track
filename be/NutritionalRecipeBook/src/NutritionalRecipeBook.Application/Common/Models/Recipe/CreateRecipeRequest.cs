using NutritionalRecipeBook.Domain.Entities;

namespace NutritionalRecipeBook.Application.Common.Models.Recipe
{
    public class CreateRecipeRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Guid> NewIngredientIds { get; set; }
        
        public double Calories { get; set; } 
        
        public double? Votes { get; set; }

        public bool? IsPremium { get; set; }
        
        public bool? IsCreatedByUser { get; set; }
    }
}
