using HA_Ossooll.API.Extensions;
using HA_Ossooll.Data.Configurations;
using HA_Ossooll.Data.Data;
using HA_Ossooll.Data.Models;
using HA_Ossooll.Services.Configurations;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddProjectDataLayer(builder.Configuration);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddApplicationServices();
builder.Services.AddApiLayer(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();