using ExpensesManager.Application.Validators;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.TestUtility.Entities;
using FluentAssertions;
using Xunit;

namespace ExpensesManager.Validators.Test.TransactionTests
{
    public class ValidateTransactionTest
    {
        [Fact]
        public void Validate_CreateTransaction_Success()
        {
            Transaction transaction = TransactionBuilder.GenerateTransaction();

            Exception exception = Record.Exception(() => TransactionValidator.Validate(transaction));

            exception.Should().BeNull();
        }

        [Theory]
        [InlineData(TransactionType.Other)]
        [InlineData(TransactionType.Food)]
        [InlineData(TransactionType.Transportation)]
        [InlineData(TransactionType.Housing)]
        [InlineData(TransactionType.Recreation)]
        [InlineData(TransactionType.Health)]
        [InlineData(TransactionType.Education)]
        [InlineData(TransactionType.Clothing)]
        [InlineData(TransactionType.Salary)]
        [InlineData(TransactionType.Investment)]
        [InlineData(TransactionType.Gift)]
        [InlineData(TransactionType.Sale)]
        public void Validate_CreateTransaction_Types_Success(TransactionType transactionType)
        {
            Transaction transaction = TransactionBuilder.GenerateTransaction(transactionType);

            Exception exception = Record.Exception(() => TransactionValidator.Validate(transaction));

            exception.Should().BeNull();
        }

        [Fact]
        public void Validate_CreateTransaction_Should_Throw_Exception_When_Description_Is_Empty()
        {
            Transaction transaction = TransactionBuilder.GenerateTransaction();

            transaction.Description = string.Empty;

            Action action = () => TransactionValidator.Validate(transaction);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.DESCRIPTION_EMPTY);
        }

        [Fact]
        public void Validate_CreateTransaction_Should_Throw_Exception_When_Description_Only_Number()
        {
            Transaction transaction = TransactionBuilder.GenerateTransaction();

            transaction.Description = "123";

            Action action = () => TransactionValidator.Validate(transaction);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.DESCRIPTION_NUMBER);
        }

        [Fact]
        public void Validate_CreateTransaction_Should_Throw_Exception_When_Amount_Is_Zero()
        {
            Transaction transaction = TransactionBuilder.GenerateTransaction();

            transaction.Amount = 0;

            Action action = () => TransactionValidator.Validate(transaction);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.AMOUNT_ZERO);
        }

        [Fact]
        public void Validate_CreateTransaction_Should_Throw_Exception_When_TransactionDate_Is_Future()
        {
            Transaction transaction = TransactionBuilder.GenerateTransaction();

            transaction.TransactionDate = transaction.TransactionDate.AddDays(1);

            Action action = () => TransactionValidator.Validate(transaction);

            action.Should().Throw<ValidationException>().WithMessage(VALIDATIONMSG.DATE_FUTURE);
        }
    }
}
