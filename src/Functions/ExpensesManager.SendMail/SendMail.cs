using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace ExpensesManager.SendMail
{
    public class SendMail
    {
        private readonly ILogger _logger;

        public SendMail(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SendMail>();
        }

        [Function("SendMail")]
        public void Run([RabbitMQTrigger("QueueName", ConnectionStringSetting = "RabbitMQConnectionURL")] string payload)
        {
            try
            {
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
