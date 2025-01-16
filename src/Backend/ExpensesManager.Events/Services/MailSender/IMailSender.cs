using System.Text.Json;

namespace ExpensesManager.Events.Services.MailSender
{
    public interface IMailSender
    {
        public void SendMail(JsonDocument jsonDocument);
    }
}
