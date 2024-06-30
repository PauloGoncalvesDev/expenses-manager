using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Index([FromServices] IGetTransaction getTransaction)
        {
            List<Transaction> incomeList = await getTransaction.Execute(Domain.Enum.CategoryType.Income);

            List<Transaction> expensesList = await getTransaction.Execute(Domain.Enum.CategoryType.Expenses);

            DashboardModel dashboardModel = new DashboardMapper().Map(incomeList, expensesList);

            return View(dashboardModel);
        }
    }
}
