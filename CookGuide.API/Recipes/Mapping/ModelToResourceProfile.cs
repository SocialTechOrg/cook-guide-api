using AutoMapper;
using CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Recipes.Dto.Response;

namespace CookGuide.API.Recipes.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Recipes, Dto.Response.RecipeUpdateResponse>();

        CreateMap<Domain.Models.Recipes, RecipeAddResponse>()
            .ForMember(dest => dest.recipeId, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
            .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.description))
            .ForMember(dest => dest.num_portions, opt => opt.MapFrom(src => src.num_portions))
            .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.category))
            .ForMember(dest => dest.accountId, opt => opt.MapFrom(src => src.accountId))
            .ForMember(dest => dest.ingredients, opt => opt.MapFrom(src => src.ingredients));
        
        CreateMap<Domain.Models.Recipes, Dto.Response.RecipeDeleteResponse>();
        CreateMap<Accounts.Domain.Models.Accounts, Dto.Response.AccountsRecipeResponse>();
        
        CreateMap<RecipesIngredients, IngredientRecipeResponse>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.IngredientId))
            .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.measurement, opt => opt.MapFrom(src => src.Measurement));
    }
}