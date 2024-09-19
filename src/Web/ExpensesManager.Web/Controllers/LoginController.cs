using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
