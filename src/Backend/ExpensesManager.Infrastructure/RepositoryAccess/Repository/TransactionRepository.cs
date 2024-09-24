using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Enum;
using ExpensesManager.Domain.Repositories.TransactionRepository;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infrastructure.RepositoryAccess.Repository
{
    public class TransactionRepository : ITransactionReadOnlyRepository, ITransactionWriteOnlyRepository
    {
        private readonly ExpensesManagerContext _context;

        public TransactionRepository(ExpensesManagerContext context)
        {
            _context = context;
        }

        public async Task Add(Transaction transaction)
        {
            await _context.Transaction.AddAsync(transaction);
        }

        public async Task<List<Transaction>> GetTransactionsByType(CategoryType categoryType)
        {
            return await _context.Transaction.Where(t => _context.Category
                                             .Any(c => c.Id == t.CategoryId && c.Type == categoryType))
                                             .ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByTypeAndUserId(CategoryType categoryType, long userId)
        {
            return await _context.Transaction.Where(t => _context.Category
                                             .Any(c => c.Id == t.CategoryId && c.Type == categoryType) 
                                             && t.UserId == userId)
                                             .ToListAsync();
        }
    }
}
