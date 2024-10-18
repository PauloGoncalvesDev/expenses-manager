using ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs;

namespace ExpensesManager.Application.BusinessRules.AdditionalInfoUserBusinessRule.cs
{
    public class UpdateAdditionalInfoUser : IUpdateAdditionalInfoUser
    {
        private readonly IAdditionalInfoUserUpdateOnlyRepository _additionalInfoUserUpdateOnlyRepository;

        private readonly IWorkUnit _workUnit;

        public UpdateAdditionalInfoUser(IAdditionalInfoUserUpdateOnlyRepository additionalInfoUserUpdateOnlyRepository, IWorkUnit workUnit)
        {
            _additionalInfoUserUpdateOnlyRepository = additionalInfoUserUpdateOnlyRepository;
            _workUnit = workUnit;
        }

        public async Task<AdditionalInfoUser> Execute(long userId)
        {
            return await _additionalInfoUserUpdateOnlyRepository.GetAdditionalInfoUserByUserIdToUpdate(userId);
        }

        public async Task Update(AdditionalInfoUser additionalInfoUser)
        {
            _additionalInfoUserUpdateOnlyRepository.Update(additionalInfoUser);

            await _workUnit.Commit();
        }
    }
}
