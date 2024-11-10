namespace ExpensesManager.Application.BusinessRules.Interfaces.UserImage
{
    public interface ICreateUserImage
    {
        public Task Execute(Domain.Entities.UserImage userImage);
    }
}
