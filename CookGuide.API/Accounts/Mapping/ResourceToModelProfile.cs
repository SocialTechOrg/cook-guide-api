using AutoMapper;
using CookGuide.API.Accounts.Dto.Request;
using CookGuide.API.Accounts.Dto.Response;

namespace CookGuide.API.Accounts.Mapping;

using CookGuide.API.Accounts.Domain.Models;

public class ResourceToModelProfile: Profile
{ 
    public ResourceToModelProfile()
    {

        CreateMap<AccountsUpdateRequest, Accounts>();
        CreateMap<AccountsSigninRequest, Accounts>();
        CreateMap<AccountsDeleteResponse, Accounts>();   
        CreateMap<AccountsLogInRequest, Accounts>();
    }
}