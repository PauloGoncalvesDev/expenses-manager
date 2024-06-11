using ExpensesManager.Domain.Enum;

namespace ExpensesManager.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public long CategoryId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public TransactionType Type { get; set; }
    }
}
