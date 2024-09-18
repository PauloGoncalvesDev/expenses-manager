namespace ExpensesManager.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeletionDate { get; set; }
    }
}
