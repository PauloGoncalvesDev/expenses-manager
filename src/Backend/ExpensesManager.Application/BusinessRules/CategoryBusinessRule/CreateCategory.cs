using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.CategoryRepository;
using ExpensesManager.Application.Validators;

namespace ExpensesManager.Application.BusinessRules.CategoryBusinessRule
{
    public class CreateCategory : ICreateCategory
    {
        private readonly ICategoryWriteOnlyRepository _categoryWriteOnlyRepository;

        public readonly IWorkUnit _workUnit;

        public CreateCategory(ICategoryWriteOnlyRepository categoryWriteOnlyRepository, IWorkUnit workUnit)
        {
            _categoryWriteOnlyRepository = categoryWriteOnlyRepository;
            _workUnit = workUnit;
        }

        public async Task Execute(Category category)
        {
            CategoryValidator.Validate(category);

            await _categoryWriteOnlyRepository.Add(category);

            await _workUnit.Commit();
        }
    }
}
