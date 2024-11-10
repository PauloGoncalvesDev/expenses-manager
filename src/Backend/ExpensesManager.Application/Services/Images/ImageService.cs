using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.ResourcesMessage;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ExpensesManager.Application.Services.Images
{
    public class ImageService
    {
        private readonly string _imagePath;

        public ImageService(string imagePath)
        {
            _imagePath = imagePath;

            if (!Directory.Exists(_imagePath))
                Directory.CreateDirectory(_imagePath);
        }

        public UserImage SaveProfileImage(string profileImage, long userId)
        {
            if (string.IsNullOrEmpty(profileImage))
                throw new ValidationException(VALIDATIONMSG.IMAGE_ERROR);

            string[] imageInformations = profileImage.Split(',');

            string mimeType = ValidateImage(imageInformations);

            string imageName = Guid.NewGuid().ToString() + GetFileExtension(mimeType);

            byte[] imageBytes = Convert.FromBase64String(imageInformations[2]);

            string imagePath = Path.Combine(_imagePath, imageName);

            File.WriteAllBytes(imagePath, imageBytes);

            int imageSize = (int)new FileInfo(imagePath).Length;

            return new UserImage
            {
                FileName = imageName,
                ImageUrl = imagePath,
                ContentType = mimeType,
                ImageSize = imageSize,
                UpdateDate = DateTime.Now,
                CreationDate = DateTime.Now,
                UserId = userId
            };
        }

        public UserImage DeleteProfileImage(UserImage existingUserImage)
        {
            if (File.Exists(existingUserImage.ImageUrl))
                File.Delete(existingUserImage.ImageUrl);

            existingUserImage.DeletionDate = DateTime.Now;

            return existingUserImage;
        }

        private static string ValidateImage(string[] imageInformations)
        {
            if (imageInformations.Length != 3 || !imageInformations[1].StartsWith("data:image"))
                throw new Exception(VALIDATIONMSG.INVALID_IMAGE_FORMAT);

            string mimeType = Regex.Match(imageInformations[1], @"data:(.*?);base64").Groups[1].Value;

            if (string.IsNullOrEmpty(mimeType))
                throw new Exception(VALIDATIONMSG.INVALID_IMAGE_FORMAT);

            return mimeType;
        }

        private string GetFileExtension(string mimeType)
        {
            return mimeType switch
            {
                "image/jpeg" => ".jpg",
                "image/png" => ".png",
                "image/webp" => ".webp",
                _ => throw new Exception(VALIDATIONMSG.INVALID_IMAGE_FORMAT)
            };
        }
    }
}
