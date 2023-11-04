namespace CookGuide.API.Recipes.Domain.Models;

public interface IRecipesRepository
{
    //CRUD
    Task<IEnumerable<Recipes>> ListAsync();
    Task<Recipes> FindByIdAsync(int id);
    Task AddAsync(Recipes recipe);
    void Update(Recipes recipe);
    void Remove(Recipes recipe);
}