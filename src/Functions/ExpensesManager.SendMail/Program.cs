using ExpensesManager.Events.Modules;
using ExpensesManager.Events.Services.MailSender;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExpensesManager.SendMail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IMailSender, MailSender>();
                    services.AddMailModule(context.Configuration);
                })
                .Build();

            host.Run();
        }
    }
}