using ExpensesManager.Domain.Entities;

namespace ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs
{
    public interface IAdditionalInfoUserWriteOnlyRepository
    {
        Task Add(AdditionalInfoUser additionalInfoUser);
    }
}
