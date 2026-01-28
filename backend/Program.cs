using Microsoft.EntityFrameworkCore;
using FinanceBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Setup Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configure CORS to allow your React App (Port 3000)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();