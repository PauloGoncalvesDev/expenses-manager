namespace ExpensesManager.Web.Models.Charts
{
    public class ChartModel
    {
        public string Title { get; set; }

        public decimal Amount { get; set; }

        public string FormatedAmount { get; set; }

        public int YearTransaction { get; set; }

        public int MonthTransaction { get; set; }
    }
}
