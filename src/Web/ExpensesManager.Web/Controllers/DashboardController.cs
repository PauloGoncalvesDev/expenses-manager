using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Application.Services.LoggedUser;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Filters;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index([FromServices] IGetTransaction getTransaction, [FromServices] ILoggedUser loggedUser)
        {
            DashboardModel dashboardModel = await GetDashboardModel(getTransaction, loggedUser);

            return View(dashboardModel);
        }

        public async Task<ActionResult> LoadCharts([FromServices] IGetTransaction getTransaction, [FromServices] ILoggedUser loggedUser)
        {
            try
            {
                DashboardModel dashboardModel = await GetDashboardModel(getTransaction, loggedUser);

                return new JsonResult(new { success = true, dashboardModel });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, error = ex.Message });
            }
        }

        private async Task<DashboardModel> GetDashboardModel([FromServices] IGetTransaction getTransaction, [FromServices] ILoggedUser loggedUser)
        {
            User user = await loggedUser.GetLoggedUser();

            List<Transaction> incomeList = await getTransaction.Execute(Domain.Enum.CategoryType.Income, user.Id);

            List<Transaction> expensesList = await getTransaction.Execute(Domain.Enum.CategoryType.Expenses, user.Id);

            DashboardModel dashboardModel = new DashboardMapper().Map(incomeList, expensesList);

            return dashboardModel;
        }
    }
}