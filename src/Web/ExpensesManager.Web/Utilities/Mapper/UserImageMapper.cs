using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Web.Utilities.Mapper
{
    public class UserImageMapper
    {
        public static UserImage Map(long userId)
        {
            return new UserImage
            {
                UserId = userId,
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now              
            };
        }
    }
}
