namespace ExpensesManager.Domain.Entities
{
    public class UserImage : BaseEntity
    {
        public string FileName { get; set; }

        public string ImageUrl { get; set; }

        public string ContentType { get; set; }

        public int ImageSize { get; set; }
    }
}
