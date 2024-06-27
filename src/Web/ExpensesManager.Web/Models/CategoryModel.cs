using static ExpensesManager.Web.Models.EnumModel;

namespace ExpensesManager.Web.Models
{
    public class CategoryModel
    {
        public string Title { get; set; }

        public CategoryType Type { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
