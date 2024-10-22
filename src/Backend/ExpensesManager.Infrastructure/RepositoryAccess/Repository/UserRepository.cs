using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infrastructure.RepositoryAccess.Repository
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
    {
        private readonly ExpensesManagerContext _context;

        public UserRepository(ExpensesManagerContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.User.AddAsync(user);
        }

        public async Task<User> GetUserByIdToUpdate(long userId)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> GetUserByMail(string mail)
        {
            return await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Mail.Equals(mail));
        }

        public void Update(User user)
        {
            _context.User.Update(user);
        }
    }
}
