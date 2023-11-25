namespace CookGuide.API.Accounts.Dto.Response;

public class AccountsSigninResponse
{
    public int id { get; set; }
    public string username { get; set; }
    public string firstName{ get; set; }
    public string lastName { get; set; }
    public string email { get; set;}
    public string? profilePicture { get; set; }
}