using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;

namespace ExpensesManager.Domain.Repositories.TransactionRepository
{
    public interface ITransactionReadOnlyRepository
    {
        public Task<List<Transaction>> GetTransactionsByType(CategoryType categoryType);

        public Task<List<Transaction>> GetTransactionsByTypeAndUserId(CategoryType categoryType, long userId);
    }
}
