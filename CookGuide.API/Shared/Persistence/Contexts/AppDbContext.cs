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
        modelBuilder.Entity<RecipesIngredients>()
            .HasKey(ri => new { ri.recipeId, ri.ingredientId });

        modelBuilder.Entity<RecipesIngredients>()
            .HasOne(ri => ri.recipe)
            .WithMany(r => r.ingredients)
            .HasForeignKey(ri => ri.recipeId);

        modelBuilder.Entity<RecipesIngredients>()
            .HasOne(ri => ri.ingredient)
            .WithMany(i => i.recipes)
            .HasForeignKey(ri => ri.ingredientId);
    }
}

