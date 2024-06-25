using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Application.Validators;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.TransactionRepository;

namespace ExpensesManager.Application.BusinessRules.TransactionBusinessRule
{
    public class CreateTransaction : ICreateTransaction
    {
        private readonly ITransactionWriteOnlyRepository _transactionWriteOnlyRepository;

        private readonly IWorkUnit _workUnit;

        public CreateTransaction(ITransactionWriteOnlyRepository transactionWriteOnlyRepository, IWorkUnit workUnit) 
        {
            _transactionWriteOnlyRepository = transactionWriteOnlyRepository;
            _workUnit = workUnit;
        }

        public async Task Execute(Transaction transaction)
        {
            TransactionValidator.Validate(transaction);

            await _transactionWriteOnlyRepository.Add(transaction);

            await _workUnit.Commit();
        }
    }
}
