using Microsoft.EntityFrameworkCore;
using zinc_api.Models.Entities;
using zinc_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var cfg = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build().GetSection("Database");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql
        (
            $"Host={cfg.GetValue<string>("HOST")};" +
            $"Port={cfg.GetValue<int>("PORT")};" +
            $"Database={cfg.GetValue<string>("DATABASE")};" +
            $"Username={cfg.GetValue<string>("USER")};" +
            $"Password={cfg.GetValue<string>("PASSWORD")}"
        )
 );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
