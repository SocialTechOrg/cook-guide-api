namespace CookGuide.API.Accounts.Dto.Response;

public class AccountsLogInResponse
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public bool? userType { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
}