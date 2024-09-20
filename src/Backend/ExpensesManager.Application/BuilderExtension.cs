using ExpensesManager.Application.BusinessRules.CategoryBusinessRule;
using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Application.BusinessRules.TransactionBusinessRule;
using ExpensesManager.Application.BusinessRules.UserBusinessRule;
using ExpensesManager.Application.Services.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager.Application
{
    public static class BuilderExtension
    {
        public static void AddApplication(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            AddApplicationServicePasswordEncryption(serviceDescriptors, configuration);

            AddApplicationCategory(serviceDescriptors);

            AddApplicationTransaction(serviceDescriptors);

            AddApplicationUser(serviceDescriptors);
        }

        private static void AddApplicationServicePasswordEncryption(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            string secretPassword = configuration.GetRequiredSection("Configuration:SecretPassword").Value ?? string.Empty;

            serviceDescriptors.AddScoped(options => new PasswordEncryption(secretPassword));
        }

        private static void AddApplicationCategory(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ICreateCategory, CreateCategory>()
                              .AddScoped<IGetCategory, GetCategory>();
        }

        private static void AddApplicationTransaction(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ICreateTransaction, CreateTransaction>()
                              .AddScoped<IGetTransaction, GetTransaction>();
        }

        private static void AddApplicationUser(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ICreateUser, CreateUser>()
                              .AddScoped<IGetUser, GetUser>();
        }
    }
}
