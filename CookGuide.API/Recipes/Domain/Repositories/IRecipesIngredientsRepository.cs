﻿namespace CookGuide.API.Recipes.Domain.Models;

public interface IRecipesIngredientsRepository
{
    //CRUD
    Task<IEnumerable<RecipesIngredients>> ListAsync();
    Task<RecipesIngredients> FindByIdAsync(int id);
    Task<IEnumerable<RecipesIngredients>> FindByRecipeIdAsync(int recipeId);
    Task AddAsync(RecipesIngredients recipeIngredient);
    void Update(RecipesIngredients recipeIngredient);
    void Remove(RecipesIngredients recipeIngredient);
}