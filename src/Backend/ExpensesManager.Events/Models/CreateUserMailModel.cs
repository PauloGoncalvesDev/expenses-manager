namespace ExpensesManager.Events.Models
{
    public class CreateUserMailModel : MailModelBase
    {
        public override string MailTo { get; set; }

        public override string Subject { get; set; }

        public override string Template { get; set; }

        public string UserName { get; set; }
    }
}
