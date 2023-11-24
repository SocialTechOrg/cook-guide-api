namespace CookGuide.API.Recipes.Dto.Request;

public class IngredientRecipeRequest
{
    public int id { get; set; }
    public int quantity { get; set; }
    public string measurement { get; set; }
}