using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager.Infrastructure.Migrations
{
    public static class MigrationExtension
    {
        public static void MigrateDataBase(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            IMigrationRunner runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();

            runner.MigrateUp();
        }
    }
}
