namespace ExpensesManager.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Mail { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeletionDate { get; set; }
    }
}
