using Microsoft.EntityFrameworkCore;

namespace CookGuide.API.Shared.Persistence.Contexts;
using CookGuide.API.Accounts.Domain.Models;
using CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Ingredients.Domain.Models;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options): base(options) {}
    
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<Recipes> Recipes { get; set; }
    public DbSet<Ingredients> Ingredients { get; set; }
    public DbSet<RecipesIngredients> RecipesIngredients { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSnakeCaseNamingConvention(); 
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipes>()
            .HasKey(r => r.id);
        
        modelBuilder.Entity<RecipesIngredients>()
            .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        modelBuilder.Entity<RecipesIngredients>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.ingredients)
            .HasForeignKey(ri => ri.RecipeId);

        modelBuilder.Entity<RecipesIngredients>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.recipes)
            .HasForeignKey(ri => ri.IngredientId);

        modelBuilder.Entity<Recipes>()
            .HasOne(r => r.account)
            .WithMany(a => a.recipes)
            .HasForeignKey(r => r.accountId);
    }
}

