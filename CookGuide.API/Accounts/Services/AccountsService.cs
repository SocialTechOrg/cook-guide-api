using CookGuide.API.Accounts.Domain.Repositories;
using CookGuide.API.Accounts.Domain.Services;
using CookGuide.API.Accounts.Domain.Services.Communication;
using CookGuide.API.Shared.Domain.Repositories;

namespace CookGuide.API.Accounts.Services;

using CookGuide.API.Accounts.Domain.Models;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository accountRepository;
    private readonly IUnitOfWork unitOfWork;

    public AccountsService(IAccountsRepository accountRepository, IUnitOfWork unitOfWork)
    {
        this.accountRepository = accountRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Accounts>> ListAsync()
    {
        return await accountRepository.ListAsync();
    }

    public async Task<AccountsApiResponse> AddAsync(Accounts account)
    {
        try
        {
            await accountRepository.AddAsync(account);
            await unitOfWork.CompleteAsync();
            return new AccountsApiResponse(account);

        }
        catch (Exception e)
        {
            return new AccountsApiResponse($"An error occurred while saving the Accounts: {e.Message}");
        }
    }
    
    public async Task<AccountsApiResponse> FindByIdAsync(int id)
    {
        var account = await accountRepository.FindByIdAsync(id);
        if (account == null)
            return new AccountsApiResponse("Account not found.");
        return new AccountsApiResponse(account);
    }
    public async Task<AccountsApiResponse> LoginAsync(Accounts account)
    {
        
        var verify_account = await accountRepository.FindByEmailAsync(account.email);
        if (verify_account == null)
            return new AccountsApiResponse("Account not found.");
        
        if(verify_account.password != account.password)
            return new AccountsApiResponse("Incorrect password.");
        
        try
        {
            await unitOfWork.CompleteAsync();
            return new AccountsApiResponse(verify_account);

        }
        catch (Exception e)
        {
            return new AccountsApiResponse($"An error occurred while saving the Accounts: {e.Message}");
        }
    }

    public async Task<AccountsApiResponse> UpdateAsync(int id, Accounts account)
    {

        var updateAccount = await accountRepository.FindByIdAsync(id);
        if (updateAccount == null)
            return new AccountsApiResponse("Account not found.");

        updateAccount.firstName = account.firstName ?? updateAccount.firstName;
        updateAccount.lastName = account.lastName ?? updateAccount.lastName;
        updateAccount.recipes = account.recipes ?? updateAccount.recipes;
        updateAccount.email = account.email ?? updateAccount.email;
        updateAccount.phone = account.phone ?? updateAccount.phone;
        updateAccount.address = account.address ?? updateAccount.address;
        updateAccount.username = account.username ?? updateAccount.username;
        updateAccount.password = account.password ?? updateAccount.password;

        try
        {
            accountRepository.Update(updateAccount);
            await unitOfWork.CompleteAsync();
            return new AccountsApiResponse(updateAccount);
        }
        catch (Exception e)
        {
            return new AccountsApiResponse($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task<AccountsApiResponse> DeleteAsync(int id)
    {
        var deleteAccount = await accountRepository.FindByIdAsync(id);
        if (deleteAccount == null)
            return new AccountsApiResponse("Account not found.");

        try
        {
            accountRepository.Remove(deleteAccount);
            await unitOfWork.CompleteAsync();
            return new AccountsApiResponse(deleteAccount);
        }
        catch (Exception e)
        {
            return new AccountsApiResponse($"An error occurred while deleting the user: {e.Message}");
        }

    }
}