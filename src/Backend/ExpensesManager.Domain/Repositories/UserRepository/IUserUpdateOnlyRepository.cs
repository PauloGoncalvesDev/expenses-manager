using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.UserRepository
{
    public interface IUserUpdateOnlyRepository
    {
        public Task<User> GetUserByIdToUpdate(long userId);

        public void Update(User user);
    }
}
