using CookGuide.API.Ingredients.Domain.Models;
using CookGuide.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CookGuide.API.Shared.Persistence.Repositories;

public class IngredientsRepository: BaseRepository, IIngredientsRepository
{
    public IngredientsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Ingredients.Domain.Models.Ingredients>> ListAsync()
    {
        return await context.Ingredients.ToListAsync();
    }

    public async Task<Ingredients.Domain.Models.Ingredients> FindByIdAsync(int id)
    {
        return await context.Ingredients.FindAsync(id);
    }

    public async Task AddAsync(Ingredients.Domain.Models.Ingredients ingredient)
    {
        await context.Ingredients.AddAsync(ingredient);
    }

    public void Update(Ingredients.Domain.Models.Ingredients ingredient)
    {
        context.Ingredients.Update(ingredient);
    }

    public void Remove(Ingredients.Domain.Models.Ingredients ingredient)
    {
        context.Ingredients.Remove(ingredient);
    }
}