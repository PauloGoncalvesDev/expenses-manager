using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;
using ExpensesManager.Domain.Repositories.TransactionRepository;

namespace ExpensesManager.Application.BusinessRules.TransactionBusinessRule
{
    public class GetTransaction : IGetTransaction
    {
        private readonly ITransactionReadOnlyRepository _transactionReadOnlyRepository;

        public GetTransaction(ITransactionReadOnlyRepository transactionReadOnlyRepository)
        {
            _transactionReadOnlyRepository = transactionReadOnlyRepository;
        }

        public async Task<List<Transaction>> Execute(CategoryType categoryType)
        {
            return await _transactionReadOnlyRepository.GetTransactionsByType(categoryType);
        }
    }
}
