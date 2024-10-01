using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.CategoryRepository;

namespace ExpensesManager.Application.BusinessRules.CategoryBusinessRule
{
    public class GetCategory : IGetCategory
    {
        private readonly ICategoryReadOnlyRepository _categoryReadOnlyRepository;

        public GetCategory(ICategoryReadOnlyRepository categoryReadOnlyRepository)
        {
            _categoryReadOnlyRepository = categoryReadOnlyRepository;
        }

        public async Task<List<Category>> Execute(long userId)
        {
            return await _categoryReadOnlyRepository.GetLastCategoriesByUserId(userId);
        }
    }
}
