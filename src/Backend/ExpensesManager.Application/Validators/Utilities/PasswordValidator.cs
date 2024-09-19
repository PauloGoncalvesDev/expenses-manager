using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;

namespace ExpensesManager.Application.Validators.Utilities
{
    public static class PasswordValidator
    {
        public static void Validate(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ValidationException(VALIDATIONMSG.PASSWORD_EMPTY);

            if (!IsStrongPassword(password))
                throw new ValidationException(VALIDATIONMSG.EXISTING_USER);
        }

        private static bool IsStrongPassword(string password)
        {
            if (password.Length < 8)
                return false;

            if (!password.Any(char.IsUpper))
                return false;

            if (!password.Any(char.IsLower))
                return false;

            if (!password.Any(char.IsDigit))
                return false;

            if (!password.Any(c => "@$!%*?&.".Contains(c)))
                return false;

            return true;
        }
    }
}
