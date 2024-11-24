using RabbitMQ.Client;

namespace ExpensesManager.Events.Configurations
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly RabbitMQSettings _rabbitMQSettings;

        private IConnection _connection;

        public RabbitMQService(RabbitMQSettings rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings;
        }

        public IConnection CreateConnection()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                ConnectionFactory connectionFactory = new ConnectionFactory()
                {
                    UserName = _rabbitMQSettings.UserName,
                    Password = _rabbitMQSettings.Password,
                    HostName = _rabbitMQSettings.HostName
                };

                _connection = connectionFactory.CreateConnection();
            }

            return _connection;
        }

        public IModel CreateChannel(string exchange, string routingKey, string queue)
        {
            IModel channel = CreateConnection().CreateModel();

            channel.ExchangeDeclare(exchange, ExchangeType.Direct, durable: true);
            channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false);
            channel.QueueBind(queue, exchange, routingKey);

            return channel;
        }
    }
}
