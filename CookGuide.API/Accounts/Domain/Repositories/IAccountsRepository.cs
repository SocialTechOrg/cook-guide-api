namespace CookGuide.API.Accounts.Domain.Repositories;
using CookGuide.API.Accounts.Domain.Models;

public interface IAccountsRepository
{
    //CRUD
    Task<IEnumerable<Accounts>> ListAsync();
    Task<Accounts> FindByIdAsync(int id);
    Task <Accounts> FindByEmailAsync(string email);
    Task AddAsync(Accounts account);
    void Update(Accounts account);
    void Remove(Accounts account);
    
}