using ExpensesManager.Domain.Enum;

namespace ExpensesManager.Domain.Entities
{
    public class AdditionalInfoUser : BaseEntity
    {
        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public GenderType Gender { get; set; }

        public string Nationality { get; set; }

        public string Occupation { get; set; }
    }
}
