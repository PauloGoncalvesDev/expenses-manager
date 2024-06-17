using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
