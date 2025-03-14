using ExpensesManager.Application.Validators;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.TestUtility.Entities;
using FluentAssertions;
using Xunit;

namespace ExpensesManager.Validators.Test.UserTests
{
    public class ValidateUserTest
    {
        [Fact]
        public void Validate_CreateUser_Success()
        {
            (User user, _) = UserBuilder.GenerateUser();

            Exception exception = Record.Exception(() => UserValidator.Validate(user));

            exception.Should().BeNull();
        }

        [Fact]
        public void Validate_CreateUser_SignUp_Success()
        {
            (User user, _) = UserBuilder.GenerateUser();

            Exception exception = Record.Exception(() => UserValidator.Validate(user, true));

            exception.Should().BeNull();
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Name_Is_Empty()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Name = string.Empty;

            Action action = () => UserValidator.Validate(user, true);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.NAME_EMPTY);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Mail_Is_Empty()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Mail = string.Empty;

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.MAIL_EMPTY);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Mail_Is_Invalid()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Mail = "invalid@mail";

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.INVALID_MAIL);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Password_Is_Empty()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Password = string.Empty;

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.PASSWORD_EMPTY);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Password_Length_Invalid()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Password = "123";

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.EXISTING_USER);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Password_UpperCase_Invalid()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Password = "teste.paulo.123";

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.EXISTING_USER);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Password_LowerCase_Invalid()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Password = "TESTE.PAULO.123";

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.EXISTING_USER);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Password_Digit_Invalid()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Password = "Teste.Paulo";

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.EXISTING_USER);
        }

        [Fact]
        public void Validate_CreateUser_Should_Throw_Exception_When_Password_SpecialCharacters_Invalid()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Password = "TestePaulo123";

            Action action = () => UserValidator.Validate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.EXISTING_USER);
        }

        [Fact]
        public void Validate_UpdateUser_Success()
        {
            (User user, _) = UserBuilder.GenerateUser();

            Exception exception = Record.Exception(() => UserValidator.ValidateToUpdate(user));

            exception.Should().BeNull();
        }

        [Fact]
        public void Validate_UpdateUser_Should_Throw_Exception_When_Name_Is_Empty()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Name = string.Empty;

            Action action = () => UserValidator.ValidateToUpdate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.NAME_EMPTY);
        }

        [Fact]
        public void Validate_UpdateUser_Should_Throw_Exception_When_Mail_Is_Empty()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Mail = string.Empty;

            Action action = () => UserValidator.ValidateToUpdate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.MAIL_EMPTY);
        }

        [Fact]
        public void Validate_UpdateUser_Should_Throw_Exception_When_Mail_Is_Invalid()
        {
            (User user, _) = UserBuilder.GenerateUser();

            user.Mail = "invalid@mail";

            Action action = () => UserValidator.ValidateToUpdate(user);

            action.Should()
                .Throw<ValidationException>()
                .WithMessage(VALIDATIONMSG.INVALID_MAIL);
        }
    }
}
