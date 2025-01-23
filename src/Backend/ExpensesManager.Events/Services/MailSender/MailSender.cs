using ExpensesManager.Events.Configurations.MailConfiguration;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace ExpensesManager.Events.Services.MailSender
{
    public class MailSender : IMailSender
    {
        private readonly MailSettings _mailSettings;

        private string _mailTo { get; set; }

        private string _subject { get; set; }

        public MailSender(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public void SendMail(JsonDocument jsonDocument)
        {
            JsonElement root = jsonDocument.RootElement;

            string message = MapMessageTemplate(root);

            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(_mailTo) || string.IsNullOrEmpty(_subject))
                return;

            var client = new SmtpClient(_mailSettings.SmtpServer, _mailSettings.Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password)
            };

            client.Send(new MailMessage
            {
                From = new MailAddress(_mailSettings.Mail),
                To = { new MailAddress(_mailTo) },
                Subject = _subject,
                Body = message,
                IsBodyHtml = true,
                BodyEncoding = System.Text.Encoding.UTF8
            });
        }

        private string MapMessageTemplate(JsonElement root)
        {
            string message = string.Empty;

            foreach (var property in root.EnumerateObject())
            {
                string propertyValue = property.Value.ToString();

                switch (property.Name)
                {
                    case "MailTo":
                        _mailTo = propertyValue;
                        break;

                    case "Subject":
                        _subject = propertyValue;
                        break;

                    case "Template":
                        message = propertyValue;
                        break;

                    default:
                        if (!string.IsNullOrEmpty(message))
                            message = message.Replace($"[[{property.Name}]]", property.Value.ToString());
                        break;
                }
            }

            return message;
        }
    }
}
