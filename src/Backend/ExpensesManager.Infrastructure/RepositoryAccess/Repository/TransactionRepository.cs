using ExpensesManager.Domain.Repositories.TransactionRepository;

namespace ExpensesManager.Infrastructure.RepositoryAccess.Repository
{
    public class TransactionRepository : ITransactionReadOnlyRepository, ITransactionWriteOnlyRepository
    {
        private readonly ExpensesManagerContext _context;

        public TransactionRepository(ExpensesManagerContext context)
        {
            _context = context;
        }
    }
}
