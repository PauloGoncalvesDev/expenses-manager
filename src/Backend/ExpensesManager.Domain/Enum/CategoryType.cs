using System.ComponentModel.DataAnnotations;

namespace ExpensesManager.Domain.Enum
{
    public enum CategoryType
    {
        [Display(Name = "Despesa")]
        Expenses = 0,
        [Display(Name = "Receita")]
        Income = 1
    }
}
