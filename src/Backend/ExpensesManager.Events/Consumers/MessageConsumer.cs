using ExpensesManager.Events.Configurations;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace ExpensesManager.Events.Consumers
{
    public class MessageConsumer : IMessageConsumer
    {
        private readonly IRabbitMQService _rabbitMQService;

        public MessageConsumer(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public async Task Consume<T>(string exchange, string routingKey, string queue, Func<T, Task> onMessageReceived)
        {
            using IModel channel = _rabbitMQService.CreateChannel(exchange, routingKey, queue);

            AsyncEventingBasicConsumer consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                byte[] body = eventArgs.Body.ToArray();

                string message = Encoding.UTF8.GetString(body);

                try
                {
                    T deserializedMessage = JsonSerializer.Deserialize<T>(message);

                    await onMessageReceived(deserializedMessage);

                    channel.BasicAck(eventArgs.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    channel.BasicNack(eventArgs.DeliveryTag, multiple: false, requeue: true);
                }
            };

            channel.BasicConsume(queue, false, consumer);

            await Task.CompletedTask;
        }
    }
}
