// Program.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using supermarket.ef.Data;
using supermarket.domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Correct DbContext registration
builder.Services.AddDbContext<SqlServerDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("supermarket.ef"))); // Use exact assembly name

// Correct identity setup - must match DbContext generic type
builder.Services.AddIdentityCore<ApplicationUser>(options => 
    {
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>() // Enable role support
    .AddEntityFrameworkStores<SqlServerDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();