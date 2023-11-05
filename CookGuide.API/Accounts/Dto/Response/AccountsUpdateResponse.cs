namespace CookGuide.API.Accounts.Dto.Response;

public class AccountsUpdateResponse
{
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
}