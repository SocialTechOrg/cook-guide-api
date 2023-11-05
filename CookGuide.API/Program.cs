using CookGuide.API.Accounts.Domain.Repositories;
using CookGuide.API.Accounts.Domain.Services;
using CookGuide.API.Accounts.Mapping;
using CookGuide.API.Accounts.Services;
using CookGuide.API.Shared.Domain.Repositories;
using CookGuide.API.Shared.Persistence.Contexts;
using CookGuide.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
 

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile)
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