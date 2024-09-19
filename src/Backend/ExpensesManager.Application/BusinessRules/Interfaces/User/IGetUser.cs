namespace ExpensesManager.Application.BusinessRules.Interfaces.User
{
    public interface IGetUser
    {
        public Task<Domain.Entities.User> Execute(string mail);
    }
}
