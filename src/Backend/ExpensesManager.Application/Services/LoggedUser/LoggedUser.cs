using ExpensesManager.Application.Services.Token;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.UserRepository;
using Microsoft.AspNetCore.Http;

namespace ExpensesManager.Application.Services.LoggedUser
{
    public class LoggedUser : ILoggedUser
    {
        private readonly TokenService _tokenService;

        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedUser(TokenService tokenService, IUserReadOnlyRepository userReadOnlyRepository, IHttpContextAccessor httpContextAccessor)
        {
            _tokenService = tokenService;
            _userReadOnlyRepository = userReadOnlyRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetLoggedUser()
        {
            string token = _httpContextAccessor.HttpContext.Request.Cookies["token_expensemanager_auth"];

            string userMail = _tokenService.GetEmailFromTokenJwt(token);

            return await _userReadOnlyRepository.GetUserByMail(userMail);
        }
    }
}
