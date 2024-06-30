using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Interfaces;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class DashboardMapper
    {
        public DashboardModel Map(List<Transaction> incomeTransactions, List<Transaction> expenseTransactions)
        {
            List<TransactionModel> incomeTransactionModel = new List<TransactionModel>();
            List<TransactionModel> expenseTransactionModel = new List<TransactionModel>();

            foreach (Transaction transaction in incomeTransactions)
                incomeTransactionModel.Add(new TransactionMapper().Map(transaction));

            foreach (Transaction transaction in expenseTransactions)
                expenseTransactionModel.Add(new TransactionMapper().Map(transaction));

            decimal incomesAmount = incomeTransactionModel.Sum(s => s.Amount);
            decimal expensesAmount = expenseTransactionModel.Sum(s => s.Amount);

            return new DashboardModel
            {
                Incomes = incomeTransactionModel,
                IncomesAmount = incomesAmount,
                Expenses = expenseTransactionModel,
                ExpensesAmount = expensesAmount,
                TotalAmount = incomesAmount - expensesAmount
            };
        }
    }
}
