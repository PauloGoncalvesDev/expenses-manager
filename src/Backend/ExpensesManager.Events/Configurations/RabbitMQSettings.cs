namespace ExpensesManager.Events.Configurations
{
    public class RabbitMQSettings
    {
        public RabbitMQSettings(string hostName, string userName, string password) 
        {
            HostName = hostName;
            UserName = userName;
            Password = password;
        }

        public readonly string HostName;

        public readonly string UserName;

        public readonly string Password;
    }
}
