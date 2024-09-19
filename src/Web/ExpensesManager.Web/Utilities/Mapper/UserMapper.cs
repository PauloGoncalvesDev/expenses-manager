using ExpensesManager.Domain.Entities;
using ExpensesManager.Web.Models;
using ExpensesManager.Web.Utilities.Interfaces;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class UserMapper : IMapper<UserModel, User>
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
    }
}
