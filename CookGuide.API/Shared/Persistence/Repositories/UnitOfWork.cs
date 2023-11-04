using CookGuide.API.Shared.Domain.Repositories;
using CookGuide.API.Shared.Persistence.Contexts;

namespace CookGuide.API.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{

    private readonly AppDbContext context;
    
    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}