using ExpensesManager.Events.Configurations;

namespace ExpensesManager.Events.Consumers
{
    public interface IMessageConsumer
    {
        public Task Consume<T>(string exchange, string routingKey, string queue, Func<T, Task> onMessageReceived);
    }
}
