namespace CookGuide.API.Recipes.Domain.Models;

public interface IRecipesIngredientsRepository
{
    //CRUD
    Task<IEnumerable<RecipesIngredients>> ListAsync();
    Task<RecipesIngredients> FindByIdAsync(int id);
    Task AddAsync(RecipesIngredients recipeIngredient);
    void Update(RecipesIngredients recipeIngredient);
    void Remove(RecipesIngredients recipeIngredient);
}