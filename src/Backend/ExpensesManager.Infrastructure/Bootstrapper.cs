using ExpensesManager.Domain.Extension;
using ExpensesManager.Infrastructure.RepositoryAccess;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExpensesManager.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddRepository(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            AddFluentMigrator(serviceDescriptors, configuration);

            AddContext(serviceDescriptors, configuration);
        }

        private static void AddFluentMigrator(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            serviceDescriptors.AddFluentMigratorCore().ConfigureRunner(c =>
            {
                c.AddSqlServer()
                .WithGlobalConnectionString(configuration.GetFullConnection())
                .ScanIn(Assembly.Load("ExpensesManager.Infrastructure"))
                .For
                .All();
            });
        }

        private static void AddContext(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            string connectionString = configuration.GetFullConnection();

            serviceDescriptors.AddDbContext<ExpensesManagerContext>(dbContext =>
            {
                dbContext.UseSqlServer(connectionString);
            });
        }
    }
}
