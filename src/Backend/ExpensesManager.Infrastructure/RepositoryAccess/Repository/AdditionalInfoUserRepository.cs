using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs;
using Microsoft.EntityFrameworkCore;

namespace ExpensesManager.Infrastructure.RepositoryAccess.Repository
{
    public class AdditionalInfoUserRepository : IAdditionalInfoUserReadOnlyRepository, IAdditionalInfoUserWriteOnlyRepository, IAdditionalInfoUserUpdateOnlyRepository
    {
        private readonly ExpensesManagerContext _context;

        public AdditionalInfoUserRepository(ExpensesManagerContext context)
        {
            _context = context;
        }

        public async Task Add(AdditionalInfoUser additionalInfoUser)
        {
            await _context.AdditionalInfoUser.AddAsync(additionalInfoUser);
        }

        public async Task<AdditionalInfoUser> GetAdditionalInfoUserByUserId(long userId)
        {
            return await _context.AdditionalInfoUser.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<AdditionalInfoUser> GetAdditionalInfoUserByUserIdToUpdate(long userId)
        {
            return await _context.AdditionalInfoUser.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public void Update(AdditionalInfoUser additionalInfoUser)
        {
            _context.AdditionalInfoUser.Update(additionalInfoUser);
        }
    }
}
