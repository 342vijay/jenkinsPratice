using Microsoft.EntityFrameworkCore;
using WebApplicationRedisPratice.Data;
using WebApplicationRedisPratice.Repositories;
using WebApplicationRedisPratice.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();


// SQL Server DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Redis Cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration =
        builder.Configuration["Redis:ConnectionString"];

    options.InstanceName = "EmployeeApi_";
});


// Repository
builder.Services.AddScoped<IEmployeeRepository,
                          EmployeeRepository>();


// Service
builder.Services.AddScoped<IEmployeeService,
                          EmployeeService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();