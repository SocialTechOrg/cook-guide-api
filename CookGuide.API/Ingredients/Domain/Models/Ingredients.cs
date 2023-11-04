namespace CookGuide.API.Ingredients.Domain.Models;
using CookGuide.API.Recipes.Domain.Models;

public class Ingredients
{
    public int id { get; set; }
    public string name { get; set; }
    public string other_names { get; set; }
    public string nutrients { get; set; }
    public string description { get; set; }
    
    public IList<RecipesIngredients> recipes { get; set; } = new List<RecipesIngredients>();

}