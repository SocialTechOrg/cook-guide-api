namespace CookGuide.API.Ingredients.Domain.Models;

public interface IIngredientsRepository
{
    //CRUD
    Task<IEnumerable<Ingredients>> ListAsync();
    Task<Ingredients> FindByIdAsync(int id);
    Task AddAsync(Ingredients ingredient);
    void Update(Ingredients ingredient);
    void Remove(Ingredients ingredient);
}