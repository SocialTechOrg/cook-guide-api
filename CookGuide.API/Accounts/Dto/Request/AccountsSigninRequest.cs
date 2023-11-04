using System.ComponentModel.DataAnnotations;

namespace CookGuide.API.Accounts.Dto.Request;

public class AccountsSigninRequest
{
    [Required]
    [MaxLength(20)]
    public string username { get; set; }

    [Required] 
    [MaxLength(20)] 
    public string password { get; set; }
}