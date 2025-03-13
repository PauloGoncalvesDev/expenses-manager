using Bogus;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;

namespace ExpensesManager.TestUtility.Entities
{
    public class TransactionBuilder
    {
        public static Transaction GenerateTransaction(TransactionType transactionType = TransactionType.Investment)
        {
            Transaction transaction = new Faker<Transaction>()
                .RuleFor(r => r.Id, _ => 1)
                .RuleFor(r => r.CategoryId, _ => 1)
                .RuleFor(r => r.TransactionDate, b => b.Date.Recent(1))
                .RuleFor(r => r.Amount, b => b.Finance.Amount())
                .RuleFor(r => r.Description, b => b.Commerce.ProductDescription())
                .RuleFor(r => r.Type, _ => transactionType);

            return transaction;
        }
    }
}
