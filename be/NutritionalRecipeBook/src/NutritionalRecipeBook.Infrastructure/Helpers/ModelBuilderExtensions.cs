using Microsoft.EntityFrameworkCore;
using NutritionalRecipeBook.Domain.Entities;

namespace NutritionalRecipeBook.Infrastructure.Helpers;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var deliveryInfos = new List<Ingredient>()
        {
            new Ingredient("Tomato"),
            new Ingredient("Lettuce"),
            new Ingredient("Cucumber"),
            new Ingredient("Carrot"),
            new Ingredient("Onion"),
            new Ingredient("Garlic"),
            new Ingredient("Bell Pepper")
        };
        
        modelBuilder.Entity<Ingredient>().HasData(deliveryInfos);
    }
}