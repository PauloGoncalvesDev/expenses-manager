using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.UserRepository;

namespace ExpensesManager.Application.BusinessRules.UserBusinessRule
{
    public class UpdateUser : IUpdateUser
    {
        private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;

        private readonly IWorkUnit _workUnit;

        public UpdateUser(IUserUpdateOnlyRepository userUpdateOnlyRepository, IWorkUnit workUnit)
        {
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
            _workUnit = workUnit;
        }

        public async Task<User> Execute(long userId)
        {
            return await _userUpdateOnlyRepository.GetUserByIdToUpdate(userId);
        }

        public async Task Update(User user)
        {
            _userUpdateOnlyRepository.Update(user);

            await _workUnit.Commit();
        }
    }
}
