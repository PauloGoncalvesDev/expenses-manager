using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models.Doughnut;
using ExpensesManager.Web.Utilities.Extension;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public static class DoughnutMapper
    {
        public static List<DoughnutExpenseModel> CreateDoughnutExpenseModel(List<Transaction> transactions)
        {
            return transactions
                            .GroupBy(g => g.Type)
                            .Select(k => new DoughnutExpenseModel
                            {
                                Title = EnumExtensions.GetDisplayName(k.First().Type),
                                Amount = k.Sum(s => s.Amount),
                                FormatedAmount = Utilities.FormatAmount(k.Sum(s => s.Amount))
                            }).ToList();
        }

        public static List<DoughnutIncomeModel> CreateDoughnutIncomeModel(List<Transaction> transactions)
        {
            return transactions
                            .GroupBy(g => g.Type)
                            .Select(k => new DoughnutIncomeModel
                            {
                                Title = EnumExtensions.GetDisplayName(k.First().Type),
                                Amount = k.Sum(s => s.Amount),
                                FormatedAmount = Utilities.FormatAmount(k.Sum(s => s.Amount))
                            }).ToList();
        }
    }
}
