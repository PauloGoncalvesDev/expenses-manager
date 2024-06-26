﻿using ExpensesManager.Application.BusinessRules.CategoryBusinessRule;
using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Application.BusinessRules.TransactionBusinessRule;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager.Application
{
    public static class BuilderExtension
    {
        public static void AddApplication(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            AddApplicationCategory(serviceDescriptors);

            AddApplicationTransaction(serviceDescriptors);
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
    }
}
