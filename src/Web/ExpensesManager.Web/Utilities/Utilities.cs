namespace ExpensesManager.Web.Utilities
{
    public static class Utilities
    {
        public static string FormatAmount(decimal amount)
        {
            string formattedAmount;

            if (Math.Abs(amount) >= 1000000)
                formattedAmount = (amount / 1000000).ToString("C", new System.Globalization.CultureInfo("pt-BR")) + "M";
            else
                formattedAmount = amount.ToString("C", new System.Globalization.CultureInfo("pt-BR"));

            return formattedAmount;
        }
    }
}
