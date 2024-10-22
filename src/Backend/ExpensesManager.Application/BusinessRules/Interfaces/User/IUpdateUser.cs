namespace ExpensesManager.Application.BusinessRules.Interfaces.User
{
    public interface IUpdateUser
    {
        public Task<Domain.Entities.User> Execute(long userId);

        public Task Update(Domain.Entities.User user);
    }
}
