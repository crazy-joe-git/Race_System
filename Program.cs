using Microsoft.EntityFrameworkCore;
using Race_System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Race_SystemDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register controllers for our Web API
builder.Services.AddControllers();

// Add Swagger/OpenAPI services for testing endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Race_System API v1");
        c.RoutePrefix = string.Empty; // Automatically opens Swagger at your root URL (https://localhost:xxxx/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map our API controllers
app.MapControllers();

app.Run();