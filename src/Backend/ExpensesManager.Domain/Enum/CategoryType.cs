using System.ComponentModel;

namespace ExpensesManager.Domain.Enum
{
    public enum CategoryType
    {
        [Description("Depesa")]
        Expenses = 0,
        [Description("Receita")]
        Income = 1
    }
}
