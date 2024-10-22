using ExpensesManager.Application.Validators.Utilities;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;

namespace ExpensesManager.Application.Validators
{
    public static class UserValidator
    {
        public static void Validate(User user, bool isSignUp = false)
        {
            if (isSignUp)
                ValidateUserName(user.Name);

            MailValidator.Validate(user.Mail);

            PasswordValidator.Validate(user.Password);
        }

        public static void ValidateToUpdate(User user)
        {
            ValidateUserName(user.Name);

            MailValidator.Validate(user.Mail);
        }

        private static void ValidateUserName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ValidationException(VALIDATIONMSG.NAME_EMPTY);
        }
    }
}
