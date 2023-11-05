namespace CookGuide.API.Accounts.Domain.Models;
using CookGuide.API.Recipes.Domain.Models;

public class Accounts
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    
    public bool? userType { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    
    
    //public int health_id { get; set; }
    //public preferences_id { get; set; }
    
    public IList<Recipes> recipes { get; set; } = new List<Recipes>();
}