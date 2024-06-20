using System.ComponentModel.DataAnnotations;

namespace ExpensesManager.Web.Models
{
    public static class EnumModel
    {
        public enum CategoryType
        {
            [Display(Name = "Despesa")]
            Expenses = 0,
            [Display(Name = "Receita")]
            Income = 1
        }
    }
}
