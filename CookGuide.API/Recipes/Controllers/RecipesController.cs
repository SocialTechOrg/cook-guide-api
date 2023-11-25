using AutoMapper;
using CookGuide.API.Recipes.Domain.Services;
using CookGuide.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CookGuide.API.Recipes.Controllers;

using CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Recipes.Dto.Request;
using CookGuide.API.Recipes.Dto.Response;

[ApiController]
[Route("api/v1/[controller]")]
public class RecipesController: ControllerBase
{
    private readonly IRecipesService recipesService;
    private readonly IMapper mapper;
    
    public RecipesController(IRecipesService recipesService, IMapper mapper)
    {
        this.recipesService = recipesService;
        this.mapper = mapper;
    }
    
    // GET: api/v1/recipes
    //Obtener lista de todas las recetas
    [HttpGet]
    public async Task<IEnumerable<RecipeAddResponse>> GetAllAsync()
    {
        var recipes = await recipesService.ListAsync();
        return mapper.Map<IEnumerable<Recipes>, IEnumerable<RecipeAddResponse>>(recipes); 
    }
    
    // GET: api/v1/recipes/{id}
    //Obtener una receta por su id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var response = await recipesService.FindByIdAsync(id);
        if (!response.Success)
            return BadRequest(response.Message);
        
        var recipeResponse = mapper.Map<Recipes, RecipeAddResponse>(response.Resource);
        return Ok(recipeResponse);
    }
    
    // POST: api/v1/recipes
    // Crear una nueva receta
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RecipeAddRequest request)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState.GetErrorMessages());
        
        var recipe = mapper.Map<RecipeAddRequest, Recipes>(request);
        var response = await recipesService.AddAsync(recipe);

        
        if (!response.Success)
            return BadRequest(response.Message);

        var recipeResponse = mapper.Map<Recipes, RecipeAddResponse>(response.Resource);
        return Ok(recipeResponse);
    }
    
    //PUT: api/v1/recipes/{id}
    //Actualizar una receta
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] RecipeUpdateRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var recipe = mapper.Map<RecipeUpdateRequest, Recipes>(request);
        var response = await recipesService.UpdateAsync(id, recipe);
        
        if (!response.Success)
            return BadRequest(response.Message);
        
        var recipeResponse = mapper.Map<Recipes, RecipeAddResponse>(response.Resource);
        return Ok(recipeResponse);
    }
    
    //DELETE: api/v1/recipes/{id}
    //Eliminar una receta
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await recipesService.DeleteAsync(id);
        if (!response.Success)
            return BadRequest(response.Message);
        
        var recipeResponse = mapper.Map<Recipes, RecipeDeleteResponse>(response.Resource);
        return Ok(recipeResponse);
    }
    
    
    // GET: api/v1/recipes/{id}/ingredients
    //Obtener lista de todos los ingredientes de una receta
    [HttpGet("{id}/ingredients")]
    public async Task<IActionResult> GetIngredientsAsync(int id)
    {
        var response = await recipesService.FindByIdAsync(id);
        if (!response.Success)
            return BadRequest(response.Message);
        
        var recipeResponse = mapper.Map<Recipes, RecipeAddResponse>(response.Resource);
        return Ok(recipeResponse.ingredients);
    }

}