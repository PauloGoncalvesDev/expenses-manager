using ExpensesManager.Events.Services.MailSender;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

namespace ExpensesManager.SendMail
{
    public class SendMail
    {
        private readonly ILogger _logger;

        private readonly IMailSender _mailSender;

        public SendMail(ILoggerFactory loggerFactory, IMailSender mailSender)
        {
            _logger = loggerFactory.CreateLogger<SendMail>();
            _mailSender = mailSender;
        }

        [Function("SendMail")]
        public void Run([RabbitMQTrigger("expensesmanager.sendmailservice.queue", ConnectionStringSetting = "RabbitMQConnectionURL")] string payload)
        {
            try
            {
                using JsonDocument payloadDocument = JsonDocument.Parse(payload);

                _mailSender.SendMail(payloadDocument);

                _logger.LogInformation($"Queue trigger function processed: {payload}");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error processing payload: {payload}");

                throw;
            }
        }
    }
}
