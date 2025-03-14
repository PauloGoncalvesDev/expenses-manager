using ExpensesManager.Application.Validators;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.TestUtility.Entities;
using FluentAssertions;
using Xunit;

namespace ExpensesManager.Validators.Test.AdditionalInfoUserTests
{
    public class ValidateAdditionalInfoUserTest
    {
        [Fact]
        public void Validate_CreateAdditionalInfoUser_Success()
        {
            AdditionalInfoUser additionalInfoUser = AdditionalInfoUserBuilder.GenerateAdditionalInfoUser();

            Exception exception = Record.Exception(() => AdditionalInfoUserValidator.Validate(additionalInfoUser));

            exception.Should().BeNull();
        }

        [Fact]
        public void Validate_CreateAdditionalInfoUser_Should_Throw_Exception_When_Occupation_Only_Number()
        {
            AdditionalInfoUser additionalInfoUser = AdditionalInfoUserBuilder.GenerateAdditionalInfoUser();

            additionalInfoUser.Occupation = "123";

            Action action = () => AdditionalInfoUserValidator.Validate(additionalInfoUser);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.OCCUPATION_NUMBER);
        }

        [Fact]
        public void Validate_CreateAdditionalInfoUser_Should_Throw_Exception_When_BirthDate_Less_Than_Minimum()
        {
            AdditionalInfoUser additionalInfoUser = AdditionalInfoUserBuilder.GenerateAdditionalInfoUser();

            additionalInfoUser.BirthDate = additionalInfoUser.BirthDate.AddYears(5);

            Action action = () => AdditionalInfoUserValidator.Validate(additionalInfoUser);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.BIRTHDATE_YEARS);
        }

        [Fact]
        public void Validate_CreateAdditionalInfoUser_Should_Throw_Exception_When_Nationality_Only_Number()
        {
            AdditionalInfoUser additionalInfoUser = AdditionalInfoUserBuilder.GenerateAdditionalInfoUser();

            additionalInfoUser.Nationality = "123";

            Action action = () => AdditionalInfoUserValidator.Validate(additionalInfoUser);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.NATIONALITY_NUMBER);
        }

        [Fact]
        public void Validate_CreateAdditionalInfoUser_Should_Throw_Exception_When_PhoneNumber_Is_Invalid()
        {
            AdditionalInfoUser additionalInfoUser = AdditionalInfoUserBuilder.GenerateAdditionalInfoUser();

            additionalInfoUser.Phone = "88996452222";

            Action action = () => AdditionalInfoUserValidator.Validate(additionalInfoUser);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.INVALID_PHONE);
        }
    }
}
