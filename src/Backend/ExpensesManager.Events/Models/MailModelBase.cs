namespace ExpensesManager.Events.Models
{
    public abstract class MailModelBase 
    {
        public abstract string MailTo { get; set; }

        public abstract string Subject { get; set; }

        public abstract string Template { get; set; }
    }
}
