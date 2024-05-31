using NutritionalRecipeBook.Domain.Entities;

namespace NutritionalRecipeBook.Application.Common.Models.Recipe
{
    public class UpdateRecipeRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Guid> NewIngredients { get; set; }
        
        public double Calories { get; set; }
        
        public double? Votes { get; set; }

        public bool? IsPremium { get; set; }
        
        public bool? IsCreatedByUser { get; set; }
    }
}
