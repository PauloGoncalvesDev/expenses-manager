using ExpensesManager.Application.Validators;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.TestUtility.Entities;
using FluentAssertions;
using Xunit;

namespace ExpensesManager.Validators.Test.CategoryTests
{
    public class ValidateCategoryTest
    {
        [Fact]
        public void Validate_CreateCategory_Success()
        {
            Category category = CategoryBuilder.GenerateCategory();

            Exception exception = Record.Exception(() => CategoryValidator.Validate(category));

            exception.Should().BeNull();
        }

        [Theory]
        [InlineData(CategoryType.Income)]
        [InlineData(CategoryType.Expenses)]
        public void Validate_CreateCategory_Types_Success(CategoryType categoryType)
        {
            Category category = CategoryBuilder.GenerateCategory(categoryType);

            Exception exception = Record.Exception(() => CategoryValidator.Validate(category));

            exception.Should().BeNull();
        }

        [Fact]
        public void Validate_CreateCategory_Should_Throw_Exception_When_Title_Is_Empty()
        {
            Category category = CategoryBuilder.GenerateCategory();

            category.Title = string.Empty;

            Action action = () => CategoryValidator.Validate(category);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.TITLE_EMPTY);
        }

        [Fact]
        public void Validate_CreateCategory_Should_Throw_Exception_When_Title_Only_Number()
        {
            Category category = CategoryBuilder.GenerateCategory();

            category.Title = "123";

            Action action = () => CategoryValidator.Validate(category);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.TITLE_NUMBER);
        }
    }
}
