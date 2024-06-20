using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddCategory([FromForm] CategoryModel categoryModel, [FromServices] ICreateCategory createCategory)
        {
            try
            {
                Category category = new CategoryMapper().Map(categoryModel);

                await createCategory.Execute(category);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
