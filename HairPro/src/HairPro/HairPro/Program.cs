using HairPro.Core.Entities;
using HairPro.DataAccess;
using HairPro.DataAccess.Persistence;
using HairPro.Shared.Services.Impl;
using HairPro.Shared.Services;
using HairPros.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HairPro.Application.Services.Auth.Interfaces;
using HairPro.Application.Services.Auth;
using System.Reflection;
using HairPro.Application;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddApplicationServices();



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DatabaseContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

    await RoleSeeder.SeedAdminUserAsync(userManager,roleManager);

    context.Database.Migrate();
  
}




app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication(); // 🔹 Identity Auth qo‘shildi
app.UseAuthorization();

app.MapControllers();
app.Run();
