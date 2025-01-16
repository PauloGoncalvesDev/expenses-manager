namespace ExpensesManager.Events.Configurations.MailConfiguration
{
    public sealed class MailSettings : MailSettingsBase
    {
        public override string SmtpServer { get; }

        public override int Port { get; }

        public override string Mail { get; }

        public override string Password { get; }

        public MailSettings(string smtpServer, int port, string mail, string password)
        {
            SmtpServer = smtpServer;
            Port = port;
            Mail = mail;
            Password = password;
        }
    }
}
