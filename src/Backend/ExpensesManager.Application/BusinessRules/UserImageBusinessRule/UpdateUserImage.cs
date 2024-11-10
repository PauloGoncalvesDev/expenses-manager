using ExpensesManager.Application.BusinessRules.Interfaces.UserImage;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.UserImageRepository;

namespace ExpensesManager.Application.BusinessRules.UserImageBusinessRule
{
    public class UpdateUserImage : IUpdateUserImage
    {
        private readonly IUserImageUpdateOnlyRepository _userImageUpdateOnlyRepository;

        private readonly IWorkUnit _workUnit;

        public UpdateUserImage(IUserImageUpdateOnlyRepository userImageUpdateOnlyRepository, IWorkUnit workUnit)
        {
            _userImageUpdateOnlyRepository = userImageUpdateOnlyRepository;
            _workUnit = workUnit;
        }

        public async Task<UserImage> Execute(long userId)
        {
            return await _userImageUpdateOnlyRepository.GetUserImageByUserIdToUpdate(userId);
        }

        public async Task Update(UserImage userImage)
        {
            _userImageUpdateOnlyRepository.Update(userImage);

            await _workUnit.Commit();
        }
    }
}
