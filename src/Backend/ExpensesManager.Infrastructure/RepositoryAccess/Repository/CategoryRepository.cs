using ExpensesManager.Domain.Repositories.CategoryRepository;

namespace ExpensesManager.Infrastructure.RepositoryAccess.Repository
{
    public class CategoryRepository : ICategoryReadOnlyRepository, ICategoryWriteOnlyRepository
    {
        private readonly ExpensesManagerContext _context;

        public CategoryRepository(ExpensesManagerContext context)
        {
            _context = context;
        }
    }
}
