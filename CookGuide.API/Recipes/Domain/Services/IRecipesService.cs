using CookGuide.API.Recipes.Domain.Services.Communication;

namespace CookGuide.API.Recipes.Domain.Services;
using CookGuide.API.Recipes.Domain.Models;

public interface IRecipesService
{
    Task<IEnumerable<Recipes>> ListAsync();
    Task<RecipeApiResponse> FindByIdAsync(int id);
    Task<RecipeApiResponse> AddAsync(Recipes recipe);
    Task<RecipeApiResponse> UpdateAsync(int id, Recipes recipe);
    Task<RecipeApiResponse> DeleteAsync(int id);
}