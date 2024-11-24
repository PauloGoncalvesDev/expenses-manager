using ExpensesManager.Events.Configurations;
using ExpensesManager.Events.Consumers;
using ExpensesManager.Events.Publishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager.Events
{
    public static class EventsModule
    {
        public static void AddRabbitMQ(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            AddRabbitMQSettings(serviceDescriptors, configuration);

            AddRabbitMQService(serviceDescriptors);

            AddConsumers(serviceDescriptors);

            AddPublishers(serviceDescriptors);
        }

        private static void AddRabbitMQSettings(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            string hostName = configuration.GetRequiredSection("Configuration:RabbitMQ:HostName").Value;

            string userName = configuration.GetRequiredSection("Configuration:RabbitMQ:UserName").Value;

            string password = configuration.GetRequiredSection("Configuration:RabbitMQ:Password").Value;

            serviceDescriptors.AddSingleton(options => new RabbitMQSettings(hostName, userName, password));
        }

        private static void AddRabbitMQService(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<IRabbitMQService, RabbitMQService>();
        }

        private static void AddConsumers(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IMessageConsumer, MessageConsumer>();
        }

        private static void AddPublishers(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddTransient<IMessagePublisher, MessagePublisher>();
        }
    }
}