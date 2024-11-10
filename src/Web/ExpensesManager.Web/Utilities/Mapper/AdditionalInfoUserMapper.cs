using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Interfaces;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class AdditionalInfoUserMapper : IMapper<AdditionalInfoUserModel, AdditionalInfoUser>
    {
        public AdditionalInfoUserModel Map(AdditionalInfoUser additionalInfoUser, User user)
        {
            return new AdditionalInfoUserModel
            {
                BirthDate = additionalInfoUser?.BirthDate,
                Gender = additionalInfoUser?.Gender,
                Mail = user.Mail,
                Name = user.Name,
                Nationality = additionalInfoUser?.Nationality,
                Occupation = additionalInfoUser?.Occupation,
                Phone = additionalInfoUser?.Phone,
                UserId = user.Id
            };
        }

        public AdditionalInfoUser Map(AdditionalInfoUser additionalInfoUser, AdditionalInfoUserModel additionalInfoUserModel)
        {
            bool hasChanges = false;

            void UpdateIfChanged<T>(T currentValue, T newValue, Action<T> updateAction)
            {
                if (!EqualityComparer<T>.Default.Equals(currentValue, newValue))
                {
                    updateAction(newValue);
                    hasChanges = true;
                }
            }

            if (additionalInfoUserModel.BirthDate.HasValue)
                UpdateIfChanged(additionalInfoUser.BirthDate, additionalInfoUserModel.BirthDate.Value, value => additionalInfoUser.BirthDate = value);

            if (additionalInfoUserModel.Gender.HasValue)
                UpdateIfChanged(additionalInfoUser.Gender, additionalInfoUserModel.Gender.Value, value => additionalInfoUser.Gender = value);

            UpdateIfChanged(additionalInfoUser.Nationality, additionalInfoUserModel.Nationality ?? string.Empty, value => additionalInfoUser.Nationality = value);

            UpdateIfChanged(additionalInfoUser.Occupation, additionalInfoUserModel.Occupation ?? string.Empty, value => additionalInfoUser.Occupation = value);

            UpdateIfChanged(additionalInfoUser.Phone, additionalInfoUserModel.Phone ?? string.Empty, value => additionalInfoUser.Phone = value);

            if (hasChanges)
            {
                additionalInfoUser.UpdateDate = DateTime.Now;
                additionalInfoUserModel.HasChange = true;
            }

            return additionalInfoUser;
        }

        public AdditionalInfoUser Map(AdditionalInfoUserModel additionalInfoUserModel)
        {
            return new AdditionalInfoUser
            {
                BirthDate = additionalInfoUserModel.BirthDate.Value,
                Gender = additionalInfoUserModel.Gender.Value,
                Nationality = additionalInfoUserModel.Nationality,
                Occupation = additionalInfoUserModel.Occupation,
                Phone = additionalInfoUserModel.Phone,
                UserId = additionalInfoUserModel.UserId.Value,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }
    }
}
