using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.UserRepository;

namespace ExpensesManager.Application.BusinessRules.UserBusinessRule
{
    public class GetUser : IGetUser
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public GetUser(IUserReadOnlyRepository userReadOnlyRepository)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task<User> Execute(string mail)
        {
            return await _userReadOnlyRepository.GetUserByMail(mail);
        }
    }
}
