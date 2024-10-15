namespace ExpensesManager.Application.BusinessRules.Interfaces.AdditionalInfoUser
{
    public interface ICreateAdditionalInfoUser
    {
        public Task Execute(Domain.Entities.AdditionalInfoUser additionalInfoUser);
    }
}
