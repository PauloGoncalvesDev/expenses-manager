using ExpensesManager.Application;
using ExpensesManager.Domain.Extension;
using ExpensesManager.Infrastructure;
using ExpensesManager.Infrastructure.Migrations;
using ExpensesManager.Events;
using ExpensesManager.Web.Filters;
using ExpensesManager.Web.Utilities.ViewComponents;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddRepository(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddRabbitMQ(builder.Configuration);
builder.Services.AddScoped<AuthorizationFilter>();
builder.Services.AddScoped<UserProfileImageViewComponent>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

UpdateDatabase();

app.Run();

void UpdateDatabase()
{
    var connection = builder.Configuration.GetConnection();
    var databaseName = builder.Configuration.GetDatabaseName();

    DataBase.CreateDataBase(connection, databaseName);

    app.MigrateDataBase();
}