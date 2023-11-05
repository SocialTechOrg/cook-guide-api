using AutoMapper;
using CookGuide.API.Accounts.Dto.Request;
using CookGuide.API.Accounts.Dto.Response;

namespace CookGuide.API.Accounts.Mapping;
using CookGuide.API.Accounts.Domain.Models;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {

        CreateMap<Accounts, AccountsUpdateResponse>();
        CreateMap<Accounts, AccountsSigninResponse>();
        CreateMap<Accounts, AccountsDeleteResponse>();
    }
    
}