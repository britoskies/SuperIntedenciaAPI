using Microsoft.AspNetCore.Identity;
using PruebaTecnicaAPI.Core.Application;
using PruebaTecnicaAPI.Infrastructure.Persistence;
using PruebaTecnicaAPI.Infrastructure.Identity;
using PruebaTecnicaAPI.Infrastructure.Identity.Entities;
using PruebaTecnicaAPI.Infrastructure.Identity.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

// Add Proyects
builder.Services.AddPersistanceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();

// OAuth2 Configuration
builder.Services.AddAuthentication()
    .AddGoogle(opt =>
    {
        opt.ClientId = builder.Configuration["Google:ClientId"];
        opt.ClientSecret = builder.Configuration["Google:ClientSecret"];
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddApiVersioning();
builder.Services.AddHealthChecks();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(opts => opts.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

// Creating seeds (roles, users) before running app
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultBasicUser.SeedAsync(userManager, roleManager);
        await DefaultAdminUser.SeedAsync(userManager, roleManager);
        
    }
    catch (Exception)
    {
        throw;
    }
}

app.Run();
