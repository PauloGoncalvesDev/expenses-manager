using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.UserImageRepository
{
    public interface IUserImageReadOnlyRepository
    {
        public Task<UserImage> GetUserImageByUserId(long userId);
    }
}
