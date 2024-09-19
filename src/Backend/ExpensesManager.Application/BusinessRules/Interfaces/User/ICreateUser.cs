namespace ExpensesManager.Application.BusinessRules.Interfaces.User
{
    public interface ICreateUser
    {
        public Task Execute(Domain.Entities.User user);
    }
}
