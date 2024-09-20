using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Application.Services.Cryptography;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.UserRepository;

namespace ExpensesManager.Application.BusinessRules.UserBusinessRule
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

        private readonly IWorkUnit _workUnit;

        private readonly PasswordEncryption _passwordEncryption;

        public CreateUser(IUserWriteOnlyRepository userWriteOnlyRepository, IWorkUnit workUnit, PasswordEncryption passwordEncryption)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _workUnit = workUnit;
            _passwordEncryption = passwordEncryption;
        }

        public async Task Execute(User user)
        {
            user.Password = _passwordEncryption.Encrypt(user.Password);

            await _userWriteOnlyRepository.Add(user);

            await _workUnit.Commit();
        }
    }
}
