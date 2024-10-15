using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs
{
    public interface IAdditionalInfoUserUpdateOnlyRepository
    {
        public Task<AdditionalInfoUser> GetAdditionalInfoUserByUserIdToUpdate(long userId);
    }
}
