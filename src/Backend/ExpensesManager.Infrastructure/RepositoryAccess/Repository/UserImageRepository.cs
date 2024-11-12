using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.UserImageRepository;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infrastructure.RepositoryAccess.Repository
{
    public class UserImageRepository : IUserImageReadOnlyRepository, IUserImageWriteOnlyRepository, IUserImageUpdateOnlyRepository
    {
        private readonly ExpensesManagerContext _context;

        public UserImageRepository(ExpensesManagerContext context)
        {
            _context = context;
        }

        public async Task Add(UserImage userImage)
        {
            await _context.UserImage.AddAsync(userImage);
        }

        public async Task<UserImage> GetUserImageByUserId(long userId)
        {
            return await _context.UserImage.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId && x.DeletionDate == null);
        }

        public async Task<UserImage> GetUserImageByUserIdToUpdate(long userId)
        {
            return await _context.UserImage.Where(x => x.UserId == userId && x.DeletionDate == null).FirstOrDefaultAsync();
        }

        public void Update(UserImage userImage)
        {
            _context.UserImage.Update(userImage);
        }
    }
}
