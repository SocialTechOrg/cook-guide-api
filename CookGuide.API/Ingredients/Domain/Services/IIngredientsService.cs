namespace CookGuide.API.Ingredients.Domain.Services;
using CookGuide.API.Ingredients.Domain.Models;

public interface IIngredientsService
{
    Task<IEnumerable<Ingredients>> ListAsync();
    Task<IngredientsApiResponse> AddAsync(Ingredients ingredient);
    Task<IngredientsApiResponse> UpdateAsync(int id, Ingredients ingredient);
    Task<IngredientsApiResponse> DeleteAsync(int id);
}