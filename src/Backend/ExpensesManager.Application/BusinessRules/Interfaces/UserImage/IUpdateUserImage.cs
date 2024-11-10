namespace ExpensesManager.Application.BusinessRules.Interfaces.UserImage
{
    public interface IUpdateUserImage
    {
        public Task<Domain.Entities.UserImage> Execute(long userId);

        public Task Update(Domain.Entities.UserImage userImage);
    }
}
