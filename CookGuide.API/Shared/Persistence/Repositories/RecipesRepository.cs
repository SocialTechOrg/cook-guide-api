using CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CookGuide.API.Shared.Persistence.Repositories;

public class RecipesRepository: BaseRepository, IRecipesRepository
{
    public RecipesRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Recipes.Domain.Models.Recipes>> ListAsync()
    {
        return await context.Recipes.ToListAsync();
    }

    public async Task<Recipes.Domain.Models.Recipes> FindByIdAsync(int id)
    {
        return await context.Recipes.FindAsync(id);
    }

    public async Task AddAsync(Recipes.Domain.Models.Recipes recipe)
    {
        await context.Recipes.AddAsync(recipe);
    }

    public void Update(Recipes.Domain.Models.Recipes recipe)
    {
        context.Recipes.Update(recipe);
    }

    public void Remove(Recipes.Domain.Models.Recipes recipe)
    {
        context.Recipes.Remove(recipe);
    }
}