using ExpensesManager.Domain.Entities;
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

        public async Task Add(Category category)
        {
            await _context.Category.AddAsync(category);
        }
    }
}
