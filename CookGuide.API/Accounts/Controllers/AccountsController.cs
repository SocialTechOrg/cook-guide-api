using AutoMapper;
using Microsoft.AspNetCore.Mvc; 
using CookGuide.API.Accounts.Domain.Services;
using CookGuide.API.Accounts.Dto.Response;
using CookGuide.API.Accounts.Dto.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using CookGuide.API.Shared.Extensions;

namespace CookGuide.API.Accounts.Controllers;

using CookGuide.API.Accounts.Domain.Models;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountsController: ControllerBase
{
    private readonly IAccountsService accountsService;
    private readonly IMapper mapper;
    
    public AccountsController(IAccountsService accountsService, IMapper mapper)
    {
        this.accountsService = accountsService;
        this.mapper = mapper;
    }
    
    // GET: api/v1/accounts
    //Obtener lista de todos los usuarios
    [HttpGet]
    public async Task<IEnumerable<AccountsSigninResponse>> GetAllAsync()
    {
        var accounts = await accountsService.ListAsync();
        return mapper.Map<IEnumerable<Accounts>, IEnumerable<AccountsSigninResponse>>(accounts); 
    }
    
    //POST: api/v1/accounts
    //Crear un nuevo usuario
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AccountsSigninRequest request)
    {
        if (!ModelState.IsValid) 
            return BadRequest(ModelState.GetErrorMessages());
        
        var account = mapper.Map<AccountsSigninRequest, Accounts>(request);
        var response = await accountsService.AddAsync(account);
        
        if (!response.Success)
            return BadRequest(response.Message);
        
        var accountResponse = mapper.Map<Accounts, AccountsSigninResponse>(response.Resource);
        return Ok(accountResponse);
    }
    
    //PUT: api/v1/accounts/{id}
    //Actualizar un usuario
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] AccountsUpdateRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var account = mapper.Map<AccountsUpdateRequest, Accounts>(request);
        var response = await accountsService.UpdateAsync(id, account);
        
        if (!response.Success)
            return BadRequest(response.Message);
        
        var accountResponse = mapper.Map<Accounts, AccountsUpdateResponse>(response.Resource);
        return Ok(accountResponse);
    }
    
    //DELETE: api/v1/accounts/{id}
    //Eliminar un usuario
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var response = await accountsService.DeleteAsync(id);
        
        if (!response.Success)
            return BadRequest(response.Message);
        
        var accountResponse = mapper.Map<Accounts, AccountsDeleteResponse>(response.Resource);
        return Ok(accountResponse);
    }
}