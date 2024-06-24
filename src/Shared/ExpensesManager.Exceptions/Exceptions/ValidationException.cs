namespace ExpensesManager.Exceptions.Exceptions
{
    public class ValidationException : ExpensesManagerException
    {
        public string ErrorMessage { get; set; }

        public ValidationException(string errorMessage) => ErrorMessage = errorMessage;
    }
}
