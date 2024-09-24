using ExpensesManager.Application.BusinessRules.Interfaces.Category;
using ExpensesManager.Application.BusinessRules.Interfaces.Transaction;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.Web.Filters;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    [ServiceFilter(typeof(AuthorizationFilter))]
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

        public async Task<ActionResult> AddTransaction([FromForm] TransactionModel transactionModel, [FromServices] ICreateTransaction createTransaction)
        {
            try
            {
                Transaction transaction = new TransactionMapper().Map(transactionModel);

                await createTransaction.Execute(transaction);

                return new JsonResult(new { success = true, message = RESPONSEMSG.TRANSACTION_SUCCESS });
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

        public async Task<ActionResult> LoadCategoriesList([FromServices] IGetCategory getCategory)
        {
            try
            {
                List<Category> categoryList = await getCategory.Execute();

                List<CategoryModel> categoryModelList = new List<CategoryModel>();

                foreach (Category category in categoryList)
                    categoryModelList.Add(new CategoryMapper().Map(category));

                return PartialView("_PartialCategoryList", categoryModelList);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, error = ex.Message });
            }
        }
    }
}
