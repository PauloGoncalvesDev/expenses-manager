using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
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

                return new JsonResult(new { success = true, category });
            }
            catch (Exception ex)
            {
                if (ex is ValidationException)
                {
                    ValidationException validationsError = ex as ValidationException;

                    return new JsonResult(new { success = false, error = validationsError.ErrorMessage });
                }

                return new JsonResult(new { success = false, error = ex.Message });
            }
        }
    }
}
