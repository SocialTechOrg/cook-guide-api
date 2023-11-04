using CookGuide.API.Shared.Persistence.Contexts;

namespace CookGuide.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext context;
    
    public BaseRepository(AppDbContext context)
    {
        this.context = context;
    }
}