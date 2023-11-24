using AutoMapper;
using CookGuide.API.Ingredients.Domain.Services;
using CookGuide.API.Ingredients.Dto.Request;
using CookGuide.API.Ingredients.Dto.Response;
using CookGuide.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CookGuide.API.Ingredients.Controllers;


using CookGuide.API.Ingredients.Domain.Models;

[ApiController]
[Route("api/v1/[controller]")]

public class IngredientsController: ControllerBase
{
    private readonly IIngredientsService ingredientsService;
    private readonly IMapper mapper;
    
    public IngredientsController(IIngredientsService ingredientsService, IMapper mapper)
    {
        this.ingredientsService = ingredientsService;
        this.mapper = mapper;
    }
    
    // GET: api/v1/ingredients
    //Obtener lista de todos los ingredientes
    [HttpGet]
    public async Task<IEnumerable<IngredientsAddResponse>> GetAllAsync()
    {
        var ingredients = await ingredientsService.ListAsync();
        return mapper.Map<IEnumerable<Ingredients>, IEnumerable<IngredientsAddResponse>>(ingredients); 
    }
    
    // POST: api/v1/ingredients
    // Crear un nuevo ingrediente
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] IngredientsAddRequest request)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState.GetErrorMessages());
        
        var ingredient = mapper.Map<IngredientsAddRequest, Ingredients>(request);
        var response = await ingredientsService.AddAsync(ingredient);
        
        if (!response.Success)
            return BadRequest(response.Message);
        
        var ingredientResponse = mapper.Map<Ingredients, IngredientsAddResponse>(response.Resource);
        return Ok(ingredientResponse);
    }
 
    //PUT: api/v1/ingredients/{id}
    //Actualizar un ingrediente
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] IngredientsUpdateRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var ingredient = mapper.Map<IngredientsUpdateRequest, Ingredients>(request);
        var response = await ingredientsService.UpdateAsync(id, ingredient);
        
        if (!response.Success)
            return BadRequest(response.Message);
        
        var ingredientResponse = mapper.Map<Ingredients, IngredientsUpdateResponse>(response.Resource);
        return Ok(ingredientResponse);
    }
    
    //DELETE: api/v1/ingredients/{id}
    //Eliminar un ingrediente
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await ingredientsService.DeleteAsync(id);
        if (!response.Success)
            return BadRequest(response.Message);
        
        var ingredientResponse = mapper.Map<Ingredients, IngredientsDeleteResponse>(response.Resource);
        return Ok(ingredientResponse);
    }
}