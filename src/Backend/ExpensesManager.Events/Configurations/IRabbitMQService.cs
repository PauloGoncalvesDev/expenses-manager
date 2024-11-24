using RabbitMQ.Client;

namespace ExpensesManager.Events.Configurations
{
    public interface IRabbitMQService
    {
        IConnection CreateConnection();

        IModel CreateChannel(string exchange, string routingKey, string queue);
    }
}
