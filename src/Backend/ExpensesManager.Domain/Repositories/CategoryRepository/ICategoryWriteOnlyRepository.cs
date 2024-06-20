using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.CategoryRepository
{
    public interface ICategoryWriteOnlyRepository
    {
        Task Add(Category category);
    }
}
