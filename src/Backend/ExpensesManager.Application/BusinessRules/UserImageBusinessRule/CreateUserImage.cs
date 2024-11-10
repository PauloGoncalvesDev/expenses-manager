using ExpensesManager.Application.BusinessRules.Interfaces.UserImage;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.UserImageRepository;

namespace ExpensesManager.Application.BusinessRules.UserImageBusinessRule
{
    public class CreateUserImage : ICreateUserImage
    {
        public IUserImageWriteOnlyRepository _userImageWriteOnlyRepository;

        public IWorkUnit _workUnit;

        public CreateUserImage(IUserImageWriteOnlyRepository userImageWriteOnlyRepository, IWorkUnit workUnit)
        {
            _userImageWriteOnlyRepository = userImageWriteOnlyRepository;
            _workUnit = workUnit;
        }

        public async Task Execute(UserImage userImage)
        {
            await _userImageWriteOnlyRepository.Add(userImage);

            await _workUnit.Commit();
        }
    }
}
