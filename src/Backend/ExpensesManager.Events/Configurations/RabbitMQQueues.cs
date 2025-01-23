namespace ExpensesManager.Events.Configurations
{
    public class RabbitMQQueues
    {
        public const string CreateUserQueue = "expensesmanager.sendmail.queue";
        public const string CreateUserExchange = "expensesmanager.sendmail.exchange";
        public const string CreateUserRouting = "expensesmanager.sendmail.routing";
    }
}
