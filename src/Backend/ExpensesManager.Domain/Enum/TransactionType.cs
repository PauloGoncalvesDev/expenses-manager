using System.ComponentModel;

namespace ExpensesManager.Domain.Enum
{
    public enum TransactionType
    {
        [Description("Outros")]
        Other = 0,
        [Description("Alimentação")]
        Food = 1,
        [Description("Transporte")]
        Transportation = 2,
        [Description("Moradia")]
        Housing = 3,
        [Description("Lazer")]
        Recreation = 4,
        [Description("Saúde")]
        Health = 5,
        [Description("Educação")]
        Education = 6,
        [Description("Vestimenta")]
        Clothing = 7,
        [Description("Salário")]
        Salary = 8,
        [Description("Investimento")]
        Investment = 9,
        [Description("Presente")]
        Gift = 10,
        [Description("Venda")]
        Sale = 11
    }
}
