using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class DashboardMapper
    {
        public DashboardModel Map(List<Transaction> incomeTransactions, List<Transaction> expenseTransactions)
        {
            List<TransactionModel> incomeTransactionModel = new List<TransactionModel>();
            List<TransactionModel> expenseTransactionModel = new List<TransactionModel>();
            List<Transaction> allTransactions = new List<Transaction>();

            foreach (Transaction transaction in incomeTransactions)
                incomeTransactionModel.Add(new TransactionMapper().Map(transaction));

            foreach (Transaction transaction in expenseTransactions)
                expenseTransactionModel.Add(new TransactionMapper().Map(transaction));

            allTransactions.AddRange(incomeTransactions);
            allTransactions.AddRange(expenseTransactions);

            decimal incomesAmount = incomeTransactionModel.Sum(s => s.Amount);
            decimal expensesAmount = expenseTransactionModel.Sum(s => s.Amount);
            decimal totalAmount = incomesAmount - expensesAmount;

            DashboardModel dashboardModel = new DashboardModel();

            dashboardModel.Incomes = incomeTransactionModel;
            dashboardModel.IncomesAmount = Utilities.FormatAmount(incomesAmount);
            dashboardModel.Expenses = expenseTransactionModel;
            dashboardModel.ExpensesAmount = Utilities.FormatAmount(expensesAmount);
            dashboardModel.TotalAmount = Utilities.FormatAmount(totalAmount);
            dashboardModel.DoughnutExpenseData = ChartMapper.CreateDoughnutExpenseModel(expenseTransactions);
            dashboardModel.DoughnutIncomeData = ChartMapper.CreateDoughnutIncomeModel(incomeTransactions);
            dashboardModel.DoughnutAllTransactionsData = ChartMapper.CreateDoughnutAllTransactions(allTransactions);
            dashboardModel.LineChartCategoryTypeData = ChartMapper.CreateLineChartCategoryType(expenseTransactions, incomeTransactions);

            return dashboardModel;
        }
    }
}
