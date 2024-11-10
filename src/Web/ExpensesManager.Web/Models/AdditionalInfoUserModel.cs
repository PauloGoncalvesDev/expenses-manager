using ExpensesManager.Domain.Enum;

namespace ExpensesManager.Web.Models
{
    public class AdditionalInfoUserModel : UserModel
    {
        public DateTime? BirthDate { get; set; }

        public string Phone { get; set; }

        public GenderType? Gender { get; set; }

        public string Nationality { get; set; }

        public string Occupation { get; set; }

        public bool HasChange { get; set; } = false;

        public string ProfileImage { get; set; }
    }
}
