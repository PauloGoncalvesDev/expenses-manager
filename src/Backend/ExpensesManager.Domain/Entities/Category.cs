using ExpensesManager.Domain.Enum;

namespace ExpensesManager.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }   

        public CategoryType Type { get; set; }
    }
}
