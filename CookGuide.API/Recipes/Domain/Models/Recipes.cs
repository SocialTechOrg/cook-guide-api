namespace CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Accounts.Domain.Models;

public class Recipes
{
    public int id { get; set; }
    public string category { get; set; }
    public int? num_portions { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int? preparationTime {get; set;}
    public string photoUrl { get; set; }
    
    public float? serving_price {get; set;}
    public IList<RecipesIngredients> ingredients { get; set; } = new List<RecipesIngredients>();
    
    public int accountId { get; set; }
    public Accounts account { get; set; }
    
}