using ExpensesManager.Events.Configurations;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ExpensesManager.Events.Publishers
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IRabbitMQService _rabbitMQService;

        public MessagePublisher(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public void Publish<T>(T message, string exchange, string routingKey, string queue)
        {
            using IModel channel = _rabbitMQService.CreateChannel(exchange, routingKey, queue);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            channel.BasicPublish(
                exchange: exchange,
                routingKey: routingKey,
                basicProperties: null,
                body: body
            );
        }
    }
}
