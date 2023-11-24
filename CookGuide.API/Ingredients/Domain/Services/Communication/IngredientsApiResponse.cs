using CookGuide.API.Shared.Domain.Services.Communication;

namespace CookGuide.API.Ingredients.Domain.Services;
using CookGuide.API.Ingredients.Domain.Models;

public class IngredientsApiResponse: ApiResponse<Ingredients>
{
    public IngredientsApiResponse(string message, Ingredients ingredient) : base(message, ingredient)
    {
    }

    public IngredientsApiResponse(string message) : base(message)
    {
    }

    public IngredientsApiResponse(Ingredients ingredient) : base(ingredient)
    {
    }
}