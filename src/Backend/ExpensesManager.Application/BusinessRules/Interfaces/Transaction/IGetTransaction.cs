using ExpensesManager.Domain.Enum;

namespace ExpensesManager.Application.BusinessRules.Interfaces.Transaction
{
    public interface IGetTransaction
    {
        public Task<List<Domain.Entities.Transaction>> Execute(CategoryType categoryType);

        public Task<List<Domain.Entities.Transaction>> Execute(CategoryType categoryType, long userId);
    }
}
