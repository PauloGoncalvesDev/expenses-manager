namespace ExpensesManager.Application.BusinessRules.Interfaces.Category
{
    public interface IGetCategory
    {
        public Task<List<Domain.Entities.Category>> Execute(long userId);
    }
}
