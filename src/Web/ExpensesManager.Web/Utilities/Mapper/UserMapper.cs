using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Interfaces;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class UserMapper : IMapper<UserModel, User>, IMapperModel<User, UserModel>
    {
        public User Map(UserModel model)
        {
            return new User
            {
                Mail = model.Mail,
                Password = model.Password,
                Name = model.Name,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };
        }

        public UserModel Map(User user)
        {
            return new UserModel
            {
                Mail = user.Mail,
                Password = user.Password,
                Name = user.Name
            };
        }

        public User Map(User user, AdditionalInfoUserModel additionalInfoUserModel)
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

            UpdateIfChanged(user.Name, additionalInfoUserModel.Name ?? string.Empty, value => user.Name = value);

            UpdateIfChanged(user.Mail, additionalInfoUserModel.Mail ?? string.Empty, value => user.Mail = value);

            if (hasChanges)
            {
                user.UpdateDate = DateTime.Now;
                additionalInfoUserModel.hasChangeUser = true;
            }

            return user;
        }
    }
}
