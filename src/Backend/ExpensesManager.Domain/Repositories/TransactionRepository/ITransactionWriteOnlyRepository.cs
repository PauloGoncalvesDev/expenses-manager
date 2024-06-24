using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.TransactionRepository
{
    public interface ITransactionWriteOnlyRepository
    {
        Task Add(Transaction transaction);
    }
}
