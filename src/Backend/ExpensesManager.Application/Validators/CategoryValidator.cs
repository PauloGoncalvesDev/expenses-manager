using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using System.Text.RegularExpressions;

namespace ExpensesManager.Application.Validators
{
    public static class CategoryValidator
    {
        public static void Validate(Category category)
        {
            ValidateTitleField(category.Title);
        }

        private static void ValidateTitleField(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ValidationException(VALIDATIONMSG.TITLE_EMPTY);

            if (Regex.IsMatch(title, @"^\d+$"))
                throw new ValidationException(VALIDATIONMSG.TITLE_NUMBER);
        }
    }
}
