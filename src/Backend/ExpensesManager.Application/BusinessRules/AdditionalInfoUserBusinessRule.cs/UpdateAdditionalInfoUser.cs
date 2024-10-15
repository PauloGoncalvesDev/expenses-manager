using ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs;

namespace ExpensesManager.Application.BusinessRules.AdditionalInfoUserBusinessRule.cs
{
    public class UpdateAdditionalInfoUser : IUpdateAdditionalInfoUser
    {
        private readonly IAdditionalInfoUserUpdateOnlyRepository _additionalInfoUserUpdateOnlyRepository;

        public UpdateAdditionalInfoUser(IAdditionalInfoUserUpdateOnlyRepository additionalInfoUserUpdateOnlyRepository)
        {
            _additionalInfoUserUpdateOnlyRepository = additionalInfoUserUpdateOnlyRepository;
        }

        public async Task<AdditionalInfoUser> Execute(long userId)
        {
            return await _additionalInfoUserUpdateOnlyRepository.GetAdditionalInfoUserByUserIdToUpdate(userId);
        }
    }
}
