using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.UserRepository
{
    public interface IUserReadOnlyRepository
    {
        public Task<User> GetUserByMail(string mail);
    }
}
