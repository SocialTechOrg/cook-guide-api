using CookGuide.API.Accounts.Domain.Repositories;
using CookGuide.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CookGuide.API.Shared.Persistence.Repositories;

public class AccountsRepository: BaseRepository, IAccountsRepository
{
    public AccountsRepository(AppDbContext context) : base(context) {}

    //Implementar interface
    
    public async Task<IEnumerable<Accounts.Domain.Models.Accounts>> ListAsync()
    {
        return await context.Accounts.ToListAsync();
    }

    public async Task<Accounts.Domain.Models.Accounts> FindByIdAsync(int id)
    {
        return await context.Accounts.FindAsync(id);
    }
    
    public async Task<Accounts.Domain.Models.Accounts> FindByEmailAsync(string email)
    {
        return await context.Accounts.FirstOrDefaultAsync(x => x.email == email);
    }
    
    public async Task AddAsync(Accounts.Domain.Models.Accounts account)
    {
        await context.Accounts.AddAsync(account);
    }
    
    public void Update(Accounts.Domain.Models.Accounts account)
    {
         context.Accounts.Update(account);
    }

    public void Remove(Accounts.Domain.Models.Accounts account)
    {
         context.Accounts.Remove(account);
    }
}