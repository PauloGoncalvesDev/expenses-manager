namespace ExpensesManager.Application.BusinessRules.Interfaces.Transaction
{
    public interface ICreateTransaction
    {
        public Task Execute(Domain.Entities.Transaction transaction);
    }
}
