using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models.Charts;
using ExpensesManager.Web.Utilities.Extension;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public static class ChartMapper
    {
        public static List<ChartExpenseModel> CreateDoughnutExpenseModel(List<Transaction> transactions)
        {
            return transactions
                            .GroupBy(g => g.Type)
                            .Select(k => new ChartExpenseModel
                            {
                                Title = EnumExtensions.GetDisplayName(k.First().Type),
                                Amount = k.Sum(s => s.Amount),
                                FormatedAmount = Utilities.FormatAmount(k.Sum(s => s.Amount)),
                                TransactionDate = k.First().TransactionDate
                            }).ToList();
        }

        public static List<ChartIncomeModel> CreateDoughnutIncomeModel(List<Transaction> transactions)
        {
            return transactions
                            .GroupBy(g => g.Type)
                            .Select(k => new ChartIncomeModel
                            {
                                Title = EnumExtensions.GetDisplayName(k.First().Type),
                                Amount = k.Sum(s => s.Amount),
                                FormatedAmount = Utilities.FormatAmount(k.Sum(s => s.Amount)),
                                TransactionDate = k.First().TransactionDate
                            }).ToList();
        }

        public static List<ChartAllTransactionsModel> CreateDoughnutAllTransactions(List<Transaction> transactions)
        {
            return transactions
                            .GroupBy(g => g.Type)
                            .Select(k => new ChartAllTransactionsModel
                            {
                                Title = EnumExtensions.GetDisplayName(k.First().Type),
                                Amount = k.Sum(s => s.Amount),
                                FormatedAmount = Utilities.FormatAmount(k.Sum(s => s.Amount))
                            }).ToList();
        }
    }
}
