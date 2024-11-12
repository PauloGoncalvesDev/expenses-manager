using ExpensesManager.Application.Services.Images;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManager.Web.Utilities.ViewComponents
{
    public class UserProfileImageViewComponent : ViewComponent
    {
        private readonly ImageService _imageService;

        public UserProfileImageViewComponent(ImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string imageBase64 = await _imageService.GetProfileImageBase64();

            return View("Default", imageBase64);
        }
    }
}
