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

            foreach (Transaction transaction in incomeTransactions)
                incomeTransactionModel.Add(new TransactionMapper().Map(transaction));

            foreach (Transaction transaction in expenseTransactions)
                expenseTransactionModel.Add(new TransactionMapper().Map(transaction));

            decimal incomesAmount = incomeTransactionModel.Sum(s => s.Amount);
            decimal expensesAmount = expenseTransactionModel.Sum(s => s.Amount);
            decimal totalAmount = incomesAmount - expensesAmount;

            return new DashboardModel
            {
                Incomes = incomeTransactionModel,
                IncomesAmount = FormatAmount(incomesAmount),
                Expenses = expenseTransactionModel,
                ExpensesAmount = FormatAmount(expensesAmount),
                TotalAmount = FormatAmount(totalAmount)
            };
        }

        private string FormatAmount(decimal amount)
        {
            string formattedAmount;

            if (Math.Abs(amount) >= 1000000)
                formattedAmount = (amount / 1000000).ToString("N2", new System.Globalization.CultureInfo("pt-BR")) + "M";
            else
                formattedAmount = amount.ToString("N2", new System.Globalization.CultureInfo("pt-BR"));

            return formattedAmount;
        }
    }
}
