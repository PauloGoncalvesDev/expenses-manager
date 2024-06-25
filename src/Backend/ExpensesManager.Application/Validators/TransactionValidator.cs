using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using System.Text.RegularExpressions;

namespace ExpensesManager.Application.Validators
{
    public static class TransactionValidator
    {
        public static void Validate(Transaction transaction)
        {
            ValidateDescriptionField(transaction.Description);

            ValidateAmountField(transaction.Amount);

            ValidateTransactionDateField(transaction.TransactionDate);
        }

        private static void ValidateDescriptionField(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ValidationException(VALIDATIONMSG.DESCRIPTION_EMPTY);

            if (Regex.IsMatch(description, @"^\d+$"))
                throw new ValidationException(VALIDATIONMSG.DESCRIPTION_NUMBER);
        }

        private static void ValidateAmountField(decimal amount)
        {
            if (amount == 0)
                throw new ValidationException(VALIDATIONMSG.AMOUNT_ZERO);
        }

        private static void ValidateTransactionDateField(DateTime transactionDate)
        {
            if (transactionDate > DateTime.Now)
                throw new ValidationException(VALIDATIONMSG.DATE_FUTURE);
        }
    }
}
