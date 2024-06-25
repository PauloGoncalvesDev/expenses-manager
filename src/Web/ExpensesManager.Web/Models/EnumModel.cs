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

        public enum TransactionType
        {
            [Display(Name = "Outros")]
            Other = 0,
            [Display(Name = "Alimentação")]
            Food = 1,
            [Display(Name = "Transporte")]
            Transportation = 2,
            [Display(Name = "Moradia")]
            Housing = 3,
            [Display(Name = "Lazer")]
            Recreation = 4,
            [Display(Name = "Saúde")]
            Health = 5,
            [Display(Name = "Educação")]
            Education = 6,
            [Display(Name = "Vestimenta")]
            Clothing = 7,
            [Display(Name = "Salário")]
            Salary = 8,
            [Display(Name = "Investimento")]
            Investment = 9,
            [Display(Name = "Presente")]
            Gift = 10,
            [Display(Name = "Venda")]
            Sale = 11
        }
    }
}
