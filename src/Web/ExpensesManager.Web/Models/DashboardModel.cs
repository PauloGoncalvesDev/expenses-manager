using ExpensesManager.Web.Models.Charts;

namespace ExpensesManager.Web.Models
{
    public class DashboardModel
    {
        public List<TransactionModel> Incomes { get; set; }

        public List<TransactionModel> Expenses { get; set; }

        public string IncomesAmount { get; set; }

        public string ExpensesAmount { get; set; }

        public string TotalAmount { get; set; }

        public List<ChartExpenseModel> DoughnutExpenseData { get; set; }

        public List<ChartIncomeModel> DoughnutIncomeData { get; set; }

        public List<ChartAllTransactionsModel> DoughnutAllTransactionsData { get; set; }

        public LineChartCategoryTypeModel LineChartCategoryTypeData { get; set; }
    }
}
