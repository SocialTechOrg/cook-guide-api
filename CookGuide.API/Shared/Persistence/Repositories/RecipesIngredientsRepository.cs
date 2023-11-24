using CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CookGuide.API.Shared.Persistence.Repositories;

public class RecipesIngredientsRepository: BaseRepository, IRecipesIngredientsRepository
{
    public RecipesIngredientsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RecipesIngredients>> ListAsync()
    {
        return await context.RecipesIngredients.ToListAsync();
    }

    public async Task<RecipesIngredients> FindByIdAsync(int id)
    {
        return await context.RecipesIngredients.FindAsync(id);
    }

    public async Task<IEnumerable<RecipesIngredients>> FindByRecipeIdAsync(int recipeId)
    {
        return await context.RecipesIngredients
            .Where(p => p.RecipeId == recipeId)
            .ToListAsync();
    }
    
    public async Task AddAsync(RecipesIngredients recipeIngredient)
    {
        await context.RecipesIngredients.AddAsync(recipeIngredient);
    }

    public void Update(RecipesIngredients recipeIngredient)
    {
        context.RecipesIngredients.Update(recipeIngredient);
    }

    public void Remove(RecipesIngredients recipeIngredient)
    {
        context.RecipesIngredients.Remove(recipeIngredient);
    }
}