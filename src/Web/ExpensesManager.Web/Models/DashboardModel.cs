using ExpensesManager.Web.Models.Doughnut;

namespace ExpensesManager.Web.Models
{
    public class DashboardModel
    {
        public List<TransactionModel> Incomes { get; set; }

        public List<TransactionModel> Expenses { get; set; }

        public string IncomesAmount { get; set; }

        public string ExpensesAmount { get; set; }

        public string TotalAmount { get; set; }

        public List<DoughnutExpenseModel> DoughnutExpenseData { get; set; }

        public List<DoughnutIncomeModel> DoughnutIncomeData { get; set; }

        public List<DoughnutAllTransactionsModel> DoughnutAllTransactionsData { get; set; }
    }
}
