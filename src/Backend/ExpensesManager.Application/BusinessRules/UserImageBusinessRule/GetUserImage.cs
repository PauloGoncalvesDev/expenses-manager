using ExpensesManager.Application.BusinessRules.Interfaces.UserImage;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories.UserImageRepository;

namespace ExpensesManager.Application.BusinessRules.UserImageBusinessRule
{
    public class GetUserImage : IGetUserImage
    {
        private readonly IUserImageReadOnlyRepository _userImageReadOnlyRepository;

        public GetUserImage(IUserImageReadOnlyRepository userImageReadOnlyRepository)
        {
            _userImageReadOnlyRepository = userImageReadOnlyRepository;
        }

        public async Task<UserImage> Execute(long userId)
        {
            return await _userImageReadOnlyRepository.GetUserImageByUserId(userId);
        }
    }
}
