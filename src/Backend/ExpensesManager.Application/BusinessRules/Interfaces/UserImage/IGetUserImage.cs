namespace ExpensesManager.Application.BusinessRules.Interfaces.UserImage
{
    public interface IGetUserImage
    {
        public Task<Domain.Entities.UserImage> Execute(long userId);
    }
}
