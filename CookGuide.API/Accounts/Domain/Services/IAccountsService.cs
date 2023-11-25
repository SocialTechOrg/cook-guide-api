using CookGuide.API.Accounts.Domain.Services.Communication;

namespace CookGuide.API.Accounts.Domain.Services;

using CookGuide.API.Accounts.Domain.Models;

public interface IAccountsService
{
    Task<IEnumerable<Accounts>> ListAsync();
    Task<AccountsApiResponse> AddAsync(Accounts account);
    Task<AccountsApiResponse> FindByIdAsync(int id);
    Task<AccountsApiResponse> LoginAsync(Accounts account);
    Task<AccountsApiResponse> UpdateAsync(int id, Accounts account);
    Task<AccountsApiResponse> DeleteAsync(int id);
}