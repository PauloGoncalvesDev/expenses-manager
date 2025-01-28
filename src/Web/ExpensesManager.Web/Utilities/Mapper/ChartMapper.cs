using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models.Charts;
using ExpensesManager.Web.Utilities.Extension;
using System.Globalization;

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
                                FormatedAmount = Utilities.FormatAmount(k.Sum(s => s.Amount))
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
                                FormatedAmount = Utilities.FormatAmount(k.Sum(s => s.Amount))
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

        public static LineChartCategoryTypeModel CreateLineChartCategoryType(List<Transaction> expenseTransactions, List<Transaction> incomeTransactions)
        {
            List<ChartExpenseModel> expenseData =
                expenseTransactions.GroupBy(m => new { m.TransactionDate.Month, m.TransactionDate.Year })
                .Select(k => new ChartExpenseModel
                {
                    Title = k.First().TransactionDate.ToString("MMMM", new CultureInfo("pt-BR")),
                    YearTransaction = k.First().TransactionDate.Year,
                    MonthTransaction = k.First().TransactionDate.Month,
                    Amount = k.Sum(s => s.Amount)
                })
                .OrderBy(k => k.YearTransaction)
                .ThenBy(k => k.MonthTransaction)
                .ToList();


            List<ChartIncomeModel> incomeData =
                incomeTransactions.GroupBy(m => new { m.TransactionDate.Month, m.TransactionDate.Year })
                .Select(k => new ChartIncomeModel
                {
                    Title = k.First().TransactionDate.ToString("MMMM", new CultureInfo("pt-BR")),
                    YearTransaction = k.First().TransactionDate.Year,
                    MonthTransaction = k.First().TransactionDate.Month,
                    Amount = k.Sum(s => s.Amount)
                })
                .OrderBy(k => k.YearTransaction)
                .ThenBy(k => k.MonthTransaction)
                .ToList();


            return new LineChartCategoryTypeModel
            {
                ExpenseData = expenseData,
                IncomeData = incomeData
            };
        }
    }
}
