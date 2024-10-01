using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.CategoryRepository;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Category>> GetLastCategoriesByUserId(long userId)
        {
            return await _context.Category.AsNoTracking()
                .Where(category => category.UserId == userId && category.DeletionDate == null)
                .OrderByDescending(order => order.CreationDate)
                .Take(10)
                .ToListAsync();
        }
    }
}
