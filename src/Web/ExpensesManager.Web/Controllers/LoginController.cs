using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Application.Services.Cryptography;
using ExpensesManager.Application.Services.Token;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login([FromForm] UserModel userModel, [FromServices] IGetUser getUser, [FromServices] PasswordEncryption passwordEncryption, [FromServices] TokenService tokenService)
        {
            try
            {
                User user = await getUser.Execute(userModel.Mail);

                ValidateUser(user, userModel.Password, passwordEncryption);

                tokenService.SaveTokenOnCookie(Response, tokenService.GenerateTokenJwt(user.Mail));

                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {
                if (ex is ValidationException)
                {
                    ValidationException validationsError = ex as ValidationException;
                    TempData["ErrorMessage"] = validationsError.ErrorMessage;

                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        private static void ValidateUser(User user, string passwordModel, [FromServices] PasswordEncryption passwordEncryption)
        {
            if (user == null || !user.Password.Equals(passwordEncryption.Encrypt(passwordModel, user.Salt)))
                throw new ValidationException(VALIDATIONMSG.EXISTING_USER);
        }
    }
}
