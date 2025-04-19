using FluentValidation;
using HairPro.Application;
using HairPro.Application.Models.User;
using HairPro.Core.Entities;
using HairPro.DataAccess;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // **To‘g‘ri klass qo‘shildi**
    c.OperationFilter<FileUploadOperationFilter>();
});
builder.Services.AddApplication(builder.Environment, builder.Configuration)
                .AddDataAccess(builder.Configuration);

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

    await RoleSeeder.SeedAdminUserAsync(userManager, roleManager);
    await AutomatedMigration.MigrateAsync(scope.ServiceProvider);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
