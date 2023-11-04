namespace CookGuide.API.Accounts.Domain.Models;
using CookGuide.API.Recipes.Domain.Models;

public class Accounts
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public bool userType { get; set; }
    
    //public int health_id { get; set; }
    //public preferences_id { get; set; }
    
    public IList<Recipes> recipes { get; set; } = new List<Recipes>();
}