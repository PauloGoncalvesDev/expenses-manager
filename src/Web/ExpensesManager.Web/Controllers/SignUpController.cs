using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Application.Validators;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddUser([FromForm] UserModel userModel, [FromServices] ICreateUser createUser, [FromServices] IGetUser getUser)
        {
            try
            {
                User user = new UserMapper().Map(userModel);

                await ValidateUser(user, getUser);

                await createUser.Execute(user);

                return View("/Views/SignUp/ConfirmSignUp.cshtml");
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

        private async Task ValidateUser(User user, [FromServices] IGetUser getUser)
        {
            User existingUser = await getUser.Execute(user.Mail);

            if (existingUser != null)
                throw new ValidationException(VALIDATIONMSG.EXISTING_USER);

            UserValidator.Validate(user, true);
        }
    }
}
