using ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs;

namespace ExpensesManager.Application.BusinessRules.AdditionalInfoUserBusinessRule.cs
{
    public class GetAdditionalInfoUser : IGetAdditionalInfoUser
    {
        private readonly IAdditionalInfoUserReadOnlyRepository _additionalInfoUserReadOnlyRepository;

        public GetAdditionalInfoUser(IAdditionalInfoUserReadOnlyRepository additionalInfoUserReadOnlyRepository)
        {
            _additionalInfoUserReadOnlyRepository = additionalInfoUserReadOnlyRepository;
        }

        public async Task<AdditionalInfoUser> Execute(long userId)
        {
            return await _additionalInfoUserReadOnlyRepository.GetAdditionalInfoUserByUserId(userId);
        }
    }
}
