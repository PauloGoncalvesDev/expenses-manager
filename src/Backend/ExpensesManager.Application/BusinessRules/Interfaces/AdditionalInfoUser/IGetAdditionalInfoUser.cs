namespace ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser
{
    public interface IGetAdditionalInfoUser
    {
        public Task<Domain.Entities.AdditionalInfoUser> Execute(long userId);
    }
}
