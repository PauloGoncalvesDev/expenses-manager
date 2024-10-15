namespace ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser
{
    public interface IUpdateAdditionalInfoUser
    {
        public Task<Domain.Entities.AdditionalInfoUser> Execute(long userId);
    }
}
