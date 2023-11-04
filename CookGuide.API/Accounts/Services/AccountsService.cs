using CookGuide.API.Accounts.Domain.Services;

namespace CookGuide.API.Accounts.Services;

using CookGuide.API.Accounts.Domain.Models;

public class AccountsService: IAccountsService
{
    public AccountsService()
    {
    }
    public Task<IEnumerable<Accounts>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Accounts> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Accounts account)
    {
        throw new NotImplementedException();
    }

    public void Update(Accounts account)
    {
        throw new NotImplementedException();
    }

    public void Delete(Accounts account)
    {
        throw new NotImplementedException();
    }
}