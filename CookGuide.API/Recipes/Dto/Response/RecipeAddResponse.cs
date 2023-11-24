using CookGuide.API.Recipes.Dto.Request;

namespace CookGuide.API.Recipes.Dto.Response;

public class RecipeAddResponse
{
    public int recipeId { get; set; }
    public string description { get; set; }
    public int num_portions { get; set; }
    public List<IngredientRecipeResponse> ingredients { get; set; }
}

