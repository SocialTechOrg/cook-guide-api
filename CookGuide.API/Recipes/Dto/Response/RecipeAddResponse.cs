﻿using CookGuide.API.Recipes.Dto.Request;

namespace CookGuide.API.Recipes.Dto.Response;

public class RecipeAddResponse
{
    public int recipeId { get; set; }
    public string name { get; set; }
    public string category { get; set; }
    public string description { get; set; }
    public int preparationTime {get; set;}
    public string photoUrl { get; set; }
    public int num_portions { get; set; }
    public float serving_price {get; set;}
    public int accountId { get; set; }
    public List<IngredientRecipeResponse> ingredients { get; set; }
}

