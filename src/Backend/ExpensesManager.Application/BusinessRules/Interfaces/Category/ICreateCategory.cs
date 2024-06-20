namespace ExpensesManager.Application.BusinessRules.Interfaces.Category
{
    public interface ICreateCategory
    {
        public Task Execute(Domain.Entities.Category category);
    }
}
