using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.UserRepository;

namespace ExpensesManager.Application.BusinessRules.UserBusinessRule
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

        private readonly IWorkUnit _workUnit;

        public CreateUser(IUserWriteOnlyRepository userWriteOnlyRepository, IWorkUnit workUnit)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _workUnit = workUnit;
        }

        public async Task Execute(User user)
        {
            await _userWriteOnlyRepository.Add(user);

            await _workUnit.Commit();
        }
    }
}
