using ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.AdditionalInfoUserRepository.cs;

namespace ExpensesManager.Application.BusinessRules.AdditionalInfoUserBusinessRule.cs
{
    public class CreateAdditionalInfoUser : ICreateAdditionalInfoUser
    {
        private readonly IWorkUnit _workUnit;

        private readonly IAdditionalInfoUserWriteOnlyRepository _additionalInfoUserWriteOnlyRepository;

        public CreateAdditionalInfoUser(IWorkUnit workUnit, IAdditionalInfoUserWriteOnlyRepository additionalInfoUserWriteOnlyRepository)
        {
            _workUnit = workUnit;
            _additionalInfoUserWriteOnlyRepository = additionalInfoUserWriteOnlyRepository;
        }

        public async Task Execute(AdditionalInfoUser additionalInfoUser)
        {
            await _additionalInfoUserWriteOnlyRepository.Add(additionalInfoUser);

            await _workUnit.Commit();
        }
    }
}
