﻿using NutritionalRecipeBook.Application.Common.Models.Recipe;
using NutritionalRecipeBook.Domain.Entities;

namespace NutritionalRecipeBook.Application.Common.Models.User
{
    public class GetUserResonse
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public UserType? UserType { get; set; }

        public List<GetRecipeResponse> FavoriteRecipes { get; set; }

        public List<ShoppingListIngredientModel> ShoppingList { get; set; }
    }
}
