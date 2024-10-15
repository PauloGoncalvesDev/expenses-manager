using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs
{
    public interface IAdditionalInfoUserReadOnlyRepository
    {
        public Task<AdditionalInfoUser> GetAdditionalInfoUserByUserId(long userId);
    }
}
