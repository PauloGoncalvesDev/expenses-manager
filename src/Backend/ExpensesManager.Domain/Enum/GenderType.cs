using System.ComponentModel.DataAnnotations;

namespace ExpensesManager.Domain.Enum
{
    public enum GenderType
    {
        [Display(Name = "Masculino")]
        Male = 0,
        [Display(Name = "Feminino")]
        Female = 1,
        [Display(Name = "Outros")]
        Other = 2
    }
}
