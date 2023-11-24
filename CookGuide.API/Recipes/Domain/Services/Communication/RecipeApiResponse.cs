using CookGuide.API.Shared.Domain.Services.Communication;

namespace CookGuide.API.Recipes.Domain.Services.Communication;
using CookGuide.API.Recipes.Domain.Models;

public class RecipeApiResponse: ApiResponse<Recipes> 
{
    public RecipeApiResponse(string message, Recipes data) : base(message, data)
    {
    }

    public RecipeApiResponse(string message) : base(message)
    {
    }

    public RecipeApiResponse(Recipes data) : base(data)
    {
    }
}