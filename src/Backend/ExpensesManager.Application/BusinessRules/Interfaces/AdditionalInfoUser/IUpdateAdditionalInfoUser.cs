namespace ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser
{
    public interface IUpdateAdditionalInfoUser
    {
        public Task<Domain.Entities.AdditionalInfoUser> Execute(long userId);

        public Task Update(Domain.Entities.AdditionalInfoUser additionalInfoUser);
    }
}
