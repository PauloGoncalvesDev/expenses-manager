using ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser;
using ExpensesManager.Application.Services.LoggedUser;
using ExpensesManager.Application.Validators;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using ExpensesManager.Infrastructure.RepositoryAccess;
using ExpensesManager.Web.Filters;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Controllers
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class UserController : Controller
    {
        public async Task<IActionResult> Index([FromServices] ILoggedUser loggedUser, [FromServices] IUpdateAdditionalInfoUser updateAdditionalInfoUser)
        {
            AdditionalInfoUserModel additionalInfoUserModel = await GetAdditionalInfoUserModel(loggedUser, updateAdditionalInfoUser);

            return View(additionalInfoUserModel);
        }

        public async Task<ActionResult> UpdateUser([FromForm] AdditionalInfoUserModel additionalInfoUserModel, [FromServices] IUpdateAdditionalInfoUser updateAdditionalInfoUser, [FromServices] ICreateAdditionalInfoUser createAdditionalInfoUser)
        {
            try
            {
                AdditionalInfoUser additionalInfoUser = await updateAdditionalInfoUser.Execute(additionalInfoUserModel.UserId.Value);

                if (additionalInfoUser == null)
                {
                    additionalInfoUser = new AdditionalInfoUserMapper().Map(additionalInfoUserModel);

                    AdditionalInfoUserValidator.Validate(additionalInfoUser);

                    await createAdditionalInfoUser.Execute(additionalInfoUser);
                }
                else
                {
                    additionalInfoUser = new AdditionalInfoUserMapper().Map(additionalInfoUser, additionalInfoUserModel);

                    AdditionalInfoUserValidator.Validate(additionalInfoUser);

                    if (additionalInfoUserModel.hasChange)
                        await updateAdditionalInfoUser.Update(additionalInfoUser);
                }

                TempData["SuccessMessage"] = RESPONSEMSG.ADDITIONALINFO_SUCCESS;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex is ValidationException)
                {
                    ValidationException validationsError = ex as ValidationException;
                    TempData["ErrorMessage"] = validationsError.ErrorMessage;

                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = VALIDATIONMSG.ADDITIONALINFO_ERROR;
                return RedirectToAction("Index");
            }
        }

        private static async Task<AdditionalInfoUserModel> GetAdditionalInfoUserModel([FromServices] ILoggedUser loggedUser, [FromServices] IUpdateAdditionalInfoUser updateAdditionalInfoUser)
        {
            User user = await loggedUser.GetLoggedUser();

            AdditionalInfoUser additionalInfoUser = await updateAdditionalInfoUser.Execute(user.Id);

            return new AdditionalInfoUserMapper().Map(additionalInfoUser, user);
        }
    }
}
