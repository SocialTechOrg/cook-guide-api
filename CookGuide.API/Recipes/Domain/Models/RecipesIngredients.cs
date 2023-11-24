using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Ingredients.Domain.Models;

public class RecipesIngredients
{
    public int RecipeId { get; set; }
    public Recipes Recipe { get; set; }

    public int IngredientId { get; set; }
    public Ingredients Ingredient { get; set; }

    public int Quantity { get; set; }

    public string Measurement { get; set; }
}