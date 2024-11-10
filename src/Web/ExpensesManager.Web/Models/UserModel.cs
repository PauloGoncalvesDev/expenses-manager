namespace ExpensesManager.Web.Models
{
    public class UserModel
    {
        public string Mail { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public long? UserId { get; set; }

        public bool HasChangeUser { get; set; } = false;
    }
}
