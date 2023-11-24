using CookGuide.API.Accounts.Domain.Repositories;
using CookGuide.API.Accounts.Domain.Services;
using CookGuide.API.Accounts.Services;
using CookGuide.API.Ingredients.Domain.Models;
using CookGuide.API.Ingredients.Domain.Services;
using CookGuide.API.Ingredients.Services;
using CookGuide.API.Recipes.Domain.Models;
using CookGuide.API.Recipes.Domain.Services;
using CookGuide.API.Recipes.Services;
using CookGuide.API.Shared.Domain.Repositories;
using CookGuide.API.Shared.Persistence.Contexts;
using CookGuide.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ModelToResourceProfileAccounts = CookGuide.API.Accounts.Mapping.ModelToResourceProfile;
using ResourceToModelProfileAccounts  = CookGuide.API.Accounts.Mapping.ResourceToModelProfile;
using ModelToResourceProfileIngredients = CookGuide.API.Ingredients.Mapping.ModelToResourceProfile;
using ResourceToModelProfileIngredients  = CookGuide.API.Ingredients.Mapping.ResourceToModelProfile;
using ModelToResourceProfileRecipes = CookGuide.API.Recipes.Mapping.ModelToResourceProfile;
using ResourceToModelProfileRecipes  = CookGuide.API.Recipes.Mapping.ResourceToModelProfile;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
builder.Services.AddScoped<IIngredientsRepository, IngredientsRepository>();
builder.Services.AddScoped<IIngredientsService, IngredientsService>();
builder.Services.AddScoped<IRecipesRepository, RecipesRepository>();
builder.Services.AddScoped<IRecipesIngredientsRepository, RecipesIngredientsRepository>();
builder.Services.AddScoped<IRecipesService, RecipesService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(
    //Accounts
    typeof(ModelToResourceProfileAccounts), 
    typeof(ResourceToModelProfileAccounts),
    //Ingredients
    typeof(ModelToResourceProfileIngredients),
    typeof(ResourceToModelProfileIngredients),
    //Recipes
    typeof(ModelToResourceProfileRecipes),
    typeof(ResourceToModelProfileRecipes)
);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();