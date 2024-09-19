using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using System.Text.RegularExpressions;

namespace ExpensesManager.Application.Validators.Utilities
{
    public static class MailValidator
    {
        public static void Validate(string mail)
        {
            if (string.IsNullOrEmpty(mail))
                throw new ValidationException(VALIDATIONMSG.MAIL_EMPTY);

            if (!Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                throw new ValidationException(VALIDATIONMSG.EXISTING_USER);
        }
    }
}
