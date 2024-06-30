namespace ExpensesManager.Web.Models
{
    public class DashboardModel
    {
        public List<TransactionModel> Incomes { get; set; }

        public List<TransactionModel> Expenses { get; set; }

        public decimal IncomesAmount {  get; set; }
        
        public decimal ExpensesAmount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
