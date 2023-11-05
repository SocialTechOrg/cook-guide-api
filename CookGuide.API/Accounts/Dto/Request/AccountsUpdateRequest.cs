using System.ComponentModel.DataAnnotations;

namespace CookGuide.API.Accounts.Dto.Request;
using CookGuide.API.Recipes.Domain.Models;

public class AccountsUpdateRequest
{
    [MaxLength(30)]
    public string? firstName { get; set; }
    
    [MaxLength(30)]
    public string? lastName { get; set; }
    
    [MaxLength(20)]
    public string? username { get; set; }
    
    [MaxLength(20)]
    public string? password { get; set; }
    
    [MaxLength(50)]
    public string? email { get; set; }
    
    [MaxLength(9)]
    public string? phone { get; set; }
    
    [MaxLength(100)]
    public string? address { get; set; }
}