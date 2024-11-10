using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.UserImageRepository
{
    public interface IUserImageUpdateOnlyRepository
    {
        public Task<UserImage> GetUserImageByUserIdToUpdate(long userId);

        public void Update(UserImage userImage);
    }
}
