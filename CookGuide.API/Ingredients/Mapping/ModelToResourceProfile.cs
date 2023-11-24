using AutoMapper;
using CookGuide.API.Ingredients.Dto.Response;

namespace CookGuide.API.Ingredients.Mapping;
using CookGuide.API.Ingredients.Domain.Models;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {

        CreateMap<Ingredients, IngredientsUpdateResponse>();
        CreateMap<Ingredients, IngredientsAddResponse>();
        CreateMap<Ingredients, IngredientsDeleteResponse>();
    }
}