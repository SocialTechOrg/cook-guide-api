namespace CookGuide.API.Recipes.Dto.Request;

public class RecipeAddRequest
{
    public string category { get; set; }
    public int num_portions { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int accountId { get; set; }
    public List<IngredientRecipeRequest> ingredients { get; set; }
    
}
