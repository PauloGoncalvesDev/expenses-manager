using ExpensesManager.Events.Configurations.MailConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesManager.Events.Modules
{
    public static class MailModule
    {
        public static void AddMailModule(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            AddMailConfiguration(serviceDescriptors, configuration);
        }

        private static void AddMailConfiguration(IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            string smtpServer = configuration.GetRequiredSection("MailSettings:SmtpServer").Value;

            int port = Convert.ToInt32(configuration.GetRequiredSection("MailSettings:Port").Value);

            string mail = configuration.GetRequiredSection("MailSettings:Mail").Value;

            string password = configuration.GetRequiredSection("MailSettings:Password").Value;

            serviceDescriptors.AddSingleton(options => new MailSettings(smtpServer, port, mail, password));
        }
    }
}
