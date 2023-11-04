namespace CookGuide.API.Accounts.Domain.Services;

using CookGuide.API.Accounts.Domain.Models;

public interface IAccountsService
{
    Task<IEnumerable<Accounts>> ListAsync();
    Task<Accounts> FindByIdAsync(int id);
    Task AddAsync(Accounts account);
    void Update(Accounts account);
    void Delete(Accounts account);
}