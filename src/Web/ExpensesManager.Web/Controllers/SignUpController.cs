using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
