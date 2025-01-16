namespace ExpensesManager.Events.Configurations.MailConfiguration
{
    public abstract class MailSettingsBase
    {
        public abstract string SmtpServer { get; }

        public abstract int Port { get; }

        public abstract string Mail { get; }

        public abstract string Password { get; }
    }
}
