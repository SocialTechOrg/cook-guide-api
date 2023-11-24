using CookGuide.API.Ingredients.Domain.Services;

namespace CookGuide.API.Ingredients.Services;

using CookGuide.API.Ingredients.Domain.Models;
using CookGuide.API.Shared.Domain.Repositories;

public class IngredientsService: IIngredientsService
{
    private readonly IIngredientsRepository ingredientsRepository;
    private readonly IUnitOfWork unitOfWork;
    
    public IngredientsService(IIngredientsRepository ingredientsRepository, IUnitOfWork unitOfWork)
    {
        this.ingredientsRepository = ingredientsRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Ingredients>> ListAsync()
    {
        return await ingredientsRepository.ListAsync();
    }
    
    public async Task<IngredientsApiResponse> AddAsync(Ingredients ingredient)
    {
        try
        {
            await ingredientsRepository.AddAsync(ingredient);
            await unitOfWork.CompleteAsync();
            return new IngredientsApiResponse(ingredient);
        }
        catch (Exception e)
        {
            return new IngredientsApiResponse($"An error occurred while saving the ingredient: {e.Message}");
        }
    }
    
    public async Task<IngredientsApiResponse> UpdateAsync(int id, Ingredients ingredient)
    {
        var updateIngredient = await ingredientsRepository.FindByIdAsync(id);
        if (updateIngredient == null)
            return new IngredientsApiResponse("Ingredient not found.");
        
        updateIngredient.name = ingredient.name ?? updateIngredient.name;
        updateIngredient.description = ingredient.description ?? updateIngredient.description;
        updateIngredient.other_names = ingredient.other_names ?? updateIngredient.other_names;
        updateIngredient.nutrients = ingredient.nutrients ?? updateIngredient.nutrients;
        
        try
        {
            ingredientsRepository.Update(updateIngredient);
            await unitOfWork.CompleteAsync();
            return new IngredientsApiResponse(updateIngredient);
        }
        catch (Exception e)
        {
            return new IngredientsApiResponse($"An error occurred while updating the ingredient: {e.Message}");
        }
    }
    
    public async Task<IngredientsApiResponse> DeleteAsync(int id)
    {
        var existingIngredient = await ingredientsRepository.FindByIdAsync(id);
        if (existingIngredient == null)
            return new IngredientsApiResponse("Ingredient not found.");
        
        try
        {
            ingredientsRepository.Remove(existingIngredient);
            await unitOfWork.CompleteAsync();
            return new IngredientsApiResponse(existingIngredient);
        }
        catch (Exception e)
        {
            return new IngredientsApiResponse($"An error occurred while deleting the ingredient: {e.Message}");
        }
    }
    
}