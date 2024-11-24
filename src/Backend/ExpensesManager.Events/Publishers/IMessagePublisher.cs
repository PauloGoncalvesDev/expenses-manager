using ExpensesManager.Events.Configurations;

namespace ExpensesManager.Events.Publishers
{
    public interface IMessagePublisher
    {
        public void Publish<T>(T message, string exchange, string routingKey, string queue);
    }
}
