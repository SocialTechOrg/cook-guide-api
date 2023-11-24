using CookGuide.API.Recipes.Domain.Models;

namespace CookGuide.API.Ingredients.Dto.Request;

public class IngredientsAddRequest
{
    public string name { get; set; }
    public string other_names { get; set; }
    public string nutrients { get; set; }
    public string description { get; set; }
    
}