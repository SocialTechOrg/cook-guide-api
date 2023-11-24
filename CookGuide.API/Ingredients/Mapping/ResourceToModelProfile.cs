using AutoMapper;

namespace CookGuide.API.Ingredients.Mapping;

using CookGuide.API.Ingredients.Dto.Request;
using CookGuide.API.Ingredients.Domain.Models;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<IngredientsAddRequest, Ingredients>();
        CreateMap<IngredientsUpdateRequest, Ingredients>();
    }
}