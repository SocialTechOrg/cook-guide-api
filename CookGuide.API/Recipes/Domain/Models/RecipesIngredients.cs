using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Ingredients.Domain.Models;

public class RecipesIngredients
{
    public int recipeId { get; set; }
    public Recipes recipe { get; set; }
    
    public int ingredientId { get; set; }
    public Ingredients ingredient { get; set; }
}