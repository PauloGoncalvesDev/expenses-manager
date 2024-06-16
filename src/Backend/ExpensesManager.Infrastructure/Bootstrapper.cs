using ExpensesManager.Domain.Extension;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.CategoryRepository;
using ExpensesManager.Domain.Repositories.TransactionRepository;
using ExpensesManager.Infrastructure.RepositoryAccess;
using ExpensesManager.Infrastructure.RepositoryAccess.Repository;
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

            AddWorkUnit(serviceDescriptors);

            AddRepositories(serviceDescriptors);
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

        private static void AddWorkUnit(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IWorkUnit, WorkUnit>();
        }

        private static void AddRepositories(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ITransactionReadOnlyRepository, TransactionRepository>()
                              .AddScoped<ITransactionWriteOnlyRepository, TransactionRepository>()
                              .AddScoped<ICategoryReadOnlyRepository, CategoryRepository>()
                              .AddScoped<ICategoryWriteOnlyRepository, CategoryRepository>();

        }
    }
}
