using Microsoft.AspNetCore.Identity;

namespace NutritionalRecipeBook.Domain.Entities
{
    public class User : IdentityUser
    {
        public List<UserRecipe> FavoriteRecipes { get; set; }

        public List<UserIngredient> ShoppingList { get; set; }

        public List<UserHydration> Hydrations { get; set; }
        
        public List<WaterNote> WaterNotes { get; set; }

        public List<RecipeComment> RecipeComments { get; set; }
        
        public List<ExercisesNote> ExercisesNotes { get; set; }
        
        public List<CalorieNote> CalorieNotes { get; set; }

        public UserType? UserType { get; set; }
    }
}
