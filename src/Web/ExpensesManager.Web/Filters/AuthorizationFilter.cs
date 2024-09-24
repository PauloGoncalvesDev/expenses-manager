using ExpensesManager.Application.Services.Token;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpensesManager.Web.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly TokenService _tokenService;

        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public AuthorizationFilter(TokenService tokenService, IUserReadOnlyRepository userReadOnlyRepository)
        {
            _tokenService = tokenService;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                string token = GetTokenFromRequest(context);

                string email = _tokenService.GetEmailFromTokenJwt(token);

                User user = await _userReadOnlyRepository.GetUserByMail(email) ?? throw new Exception();
            }
            catch (Exception ex)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }

        private static string GetTokenFromRequest(AuthorizationFilterContext context)
        {
            return context.HttpContext.Request.Cookies["token_expensemanager_auth"] ?? throw new Exception();
        }
    }
}
