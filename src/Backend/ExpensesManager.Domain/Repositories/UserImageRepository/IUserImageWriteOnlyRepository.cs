using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.UserImageRepository
{
    public interface IUserImageWriteOnlyRepository
    {
        Task Add(UserImage userImage);
    }
}
