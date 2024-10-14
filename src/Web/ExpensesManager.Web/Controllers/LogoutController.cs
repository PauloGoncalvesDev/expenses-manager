using ExpensesManager.Application.Services.Token;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logout([FromServices] TokenService tokenService)
        {
            tokenService.DeleteCookie(Response);

            return RedirectToAction("Index", "Login");
        }
    }
}
