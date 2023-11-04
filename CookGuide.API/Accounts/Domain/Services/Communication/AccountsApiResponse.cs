using CookGuide.API.Shared.Domain.Services.Communication;

namespace CookGuide.API.Accounts.Domain.Services.Communication;
using CookGuide.API.Accounts.Domain.Models;


public class AccountsApiResponse: ApiResponse<Accounts>
{
    public AccountsApiResponse(string message, Accounts account): base(message, account)
    {
    }
    
    public AccountsApiResponse(Accounts account): base(account)
    {
    }
    
    public AccountsApiResponse(string message): base(message)
    {
    }
    
}

