using AutoMapper;
using CookGuide.API.Recipes.Dto.Response;

namespace CookGuide.API.Recipes.Mapping;
using CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Recipes.Dto.Request;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        // Mapeo existente para RecipeAddRequest a Recipes
        CreateMap<RecipeAddRequest, Recipes>()
            .ForMember(dest => dest.ingredients, opt => opt.MapFrom(src => 
                src.ingredients.Select(i => new RecipesIngredients 
                { 
                    IngredientId = i.id, 
                    Quantity = i.quantity, 
                    Measurement = i.measurement 
                }).ToList()));
        
        CreateMap<RecipeUpdateRequest, Recipes>()
            .ForMember(dest => dest.ingredients, opt => opt.MapFrom(src => 
                src.ingredients.Select(i => new RecipesIngredients 
                { 
                    IngredientId = i.id, 
                    Quantity = i.quantity, 
                    Measurement = i.measurement 
                }).ToList()));
        
        // Mapeo específico para IngredientRecipeRequest a RecipesIngredients
        CreateMap<IngredientRecipeRequest, RecipesIngredients>()
            .ForMember(dest => dest.IngredientId, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.quantity))
            .ForMember(dest => dest.Measurement, opt => opt.MapFrom(src => src.measurement));
    }
}