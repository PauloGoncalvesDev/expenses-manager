using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.CategoryRepository
{
    public interface ICategoryReadOnlyRepository
    {
        public Task<List<Category>> GetLastCategories();
    }
}
