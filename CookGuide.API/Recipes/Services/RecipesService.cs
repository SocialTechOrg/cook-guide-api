using AutoMapper;
using CookGuide.API.Accounts.Domain.Repositories;
using CookGuide.API.Recipes.Domain.Services;
using CookGuide.API.Recipes.Domain.Services.Communication;
using CookGuide.API.Recipes.Dto.Request;
using CookGuide.API.Recipes.Dto.Response;
using CookGuide.API.Shared.Domain.Repositories;
using CookGuide.API.Shared.Persistence.Repositories;

namespace CookGuide.API.Recipes.Services;
using CookGuide.API.Recipes.Domain.Models;

public class RecipesService: IRecipesService
{
    
    private readonly IRecipesRepository recipesRepository;
    private readonly IRecipesIngredientsRepository recipesIngredientsRepository;
    private readonly IAccountsRepository accountsRepository;
    private readonly IUnitOfWork unitOfWork;

    public RecipesService(IRecipesRepository recipesRepository,
        IRecipesIngredientsRepository recipesIngredientsRepository, IAccountsRepository accountsRepository,
        IUnitOfWork unitOfWork)
    {
        this.recipesRepository = recipesRepository;
        this.recipesIngredientsRepository = recipesIngredientsRepository;
        this.accountsRepository = accountsRepository;
        this.unitOfWork = unitOfWork;
    }
    
    
    public async Task<IEnumerable<Recipes>> ListAsync()
    {
        return await recipesRepository.ListAsync();
    }

    public async Task<RecipeApiResponse> AddAsync(Recipes recipe)
    { 
        try
        {
            //Busca la cuenta asociada con el Id
            var account = await accountsRepository.FindByIdAsync(recipe.accountId);
            if (account == null)
            {
                return new RecipeApiResponse("Account not found.");
            }
            
            //Crea una lista de ingredientes
            var ingredients = recipe.ingredients;
            
            //Agrega el entity Recipes a la base de datos
            await recipesRepository.AddAsync(recipe);
            
            await unitOfWork.CompleteAsync();
            return new RecipeApiResponse(recipe);
        }
        catch (Exception e)
        {
            return new RecipeApiResponse($"An error occurred while saving the recipe: {e.Message}");
        }
    }
    
    public async Task<RecipeApiResponse> FindByIdAsync(int id)
    {
        var existingRecipe = await recipesRepository.FindByIdAsync(id);
        if (existingRecipe == null)
            return new RecipeApiResponse("Recipe not found.");
        return new RecipeApiResponse(existingRecipe);
    }

    public async Task<RecipeApiResponse> UpdateAsync(int id, Recipes recipe)
    {
        var updateRecipe = await recipesRepository.FindByIdAsync(id);
        if (updateRecipe == null)
            return new RecipeApiResponse("Recipe not found.");
        
        updateRecipe.description = recipe.description ?? updateRecipe.description;
        updateRecipe.ingredients = recipe.ingredients ?? updateRecipe.ingredients;
        updateRecipe.category = recipe.category ?? updateRecipe.category;
        updateRecipe.num_portions = recipe.num_portions ?? updateRecipe.num_portions;
        
        try
        {
            recipesRepository.Update(updateRecipe);
            await unitOfWork.CompleteAsync();
            return new RecipeApiResponse(updateRecipe);
        }
        catch (Exception e)
        {
            return new RecipeApiResponse($"An error occurred while updating the recipe: {e.Message}");
        }
        
        
    }

    public async Task<RecipeApiResponse> DeleteAsync(int id)
    {
        var existingRecipe = await recipesRepository.FindByIdAsync(id);
        if (existingRecipe == null)
            return new RecipeApiResponse("Recipe not found.");
        try
        {
            var recipeIngredients = await recipesIngredientsRepository.FindByRecipeIdAsync(id);
            foreach (var recipeIngredient in recipeIngredients)
            {
                recipesIngredientsRepository.Remove(recipeIngredient);
            }
            
            recipesRepository.Remove(existingRecipe);
            await unitOfWork.CompleteAsync();
            return new RecipeApiResponse(existingRecipe);
        }
        catch (Exception e)
        {
            return new RecipeApiResponse($"An error occurred while deleting the recipe: {e.Message}");
        }
    }
}