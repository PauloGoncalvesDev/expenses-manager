using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.UserRepository
{
    public interface IUserWriteOnlyRepository
    {
        Task Add(User user);
    }
}
