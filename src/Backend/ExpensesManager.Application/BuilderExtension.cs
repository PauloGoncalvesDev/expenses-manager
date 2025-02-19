﻿using ExpensesManager.Application.BusinessRules.AdditionalInfoUserBusinessRule.cs;
using ExpensesManager.Application.BusinessRules.CategoryBusinessRule;
using ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser;
using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Application.BusinessRules.Interfaces.UserImage;
using ExpensesManager.Application.BusinessRules.TransactionBusinessRule;
using ExpensesManager.Application.BusinessRules.UserBusinessRule;
using ExpensesManager.Application.BusinessRules.UserImageBusinessRule;
using ExpensesManager.Application.Services.Cryptography;
using ExpensesManager.Application.Services.Images;
using ExpensesManager.Application.Services.LoggedUser;
using ExpensesManager.Application.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager.Application
{
    public static class BuilderExtension
    {
        public static void AddApplication(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            AddApplicationServicePasswordEncryption(serviceDescriptors);

            AddApplicationServiceTokenJWT(serviceDescriptors, configuration);

            AddApplicationLoggedUser(serviceDescriptors);

            AddApplicationImageService(serviceDescriptors, configuration);

            AddApplicationBusinessRule(serviceDescriptors);
        }

        private static void AddApplicationServicePasswordEncryption(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped(options => new PasswordEncryption());
        }

        private static void AddApplicationServiceTokenJWT(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            int expirationTime = Convert.ToInt32(configuration.GetRequiredSection("Configuration:Jwt:JwtExpirationTime").Value);

            string securityPassword = configuration.GetRequiredSection("Configuration:Jwt:JwtSecurityPassword").Value;

            serviceDescriptors.AddScoped(options => new TokenService(securityPassword, expirationTime));
        }

        private static void AddApplicationImageService(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            string imagePath = configuration.GetRequiredSection("Configuration:ProfileImagePath").Value;

            serviceDescriptors.AddScoped<ImageService>(options =>
            {
                var loggedUser = options.GetRequiredService<ILoggedUser>();
                var getUserImage = options.GetRequiredService<IGetUserImage>();

                return new ImageService(imagePath, getUserImage, loggedUser);
            });
        }

        private static void AddApplicationBusinessRule(IServiceCollection serviceDescriptors)
        {
            AddApplicationCategory(serviceDescriptors);

            AddApplicationTransaction(serviceDescriptors);

            AddApplicationUser(serviceDescriptors);

            AddApplicationAdditionalInfoUser(serviceDescriptors);

            AddApplicationUserImage(serviceDescriptors);
        }

        private static void AddApplicationLoggedUser(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ILoggedUser, LoggedUser>();
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
                              .AddScoped<IGetUser, GetUser>()
                              .AddScoped<IUpdateUser, UpdateUser>();
        }

        private static void AddApplicationAdditionalInfoUser(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ICreateAdditionalInfoUser, CreateAdditionalInfoUser>()
                              .AddScoped<IGetAdditionalInfoUser, GetAdditionalInfoUser>()
                              .AddScoped<IUpdateAdditionalInfoUser, UpdateAdditionalInfoUser>();
        }

        private static void AddApplicationUserImage(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ICreateUserImage, CreateUserImage>()
                              .AddScoped<IGetUserImage, GetUserImage>()
                              .AddScoped<IUpdateUserImage, UpdateUserImage>();
        }
    }
}
