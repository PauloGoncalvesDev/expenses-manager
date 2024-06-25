using static ExpensesManager.Web.Models.EnumModel;

namespace ExpensesManager.Web.Models
{
    public class TransactionModel
    {
        public long CategoryId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public TransactionType Type { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
