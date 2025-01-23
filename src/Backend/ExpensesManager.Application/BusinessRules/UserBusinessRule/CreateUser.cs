using ExpensesManager.Application.BusinessRules.Interfaces.User;
using ExpensesManager.Application.Services.Cryptography;
using ExpensesManager.Domain.Entities;
using ExpensesManager.Domain.Repositories;
using ExpensesManager.Domain.Repositories.UserRepository;
using ExpensesManager.Events.Configurations;
using ExpensesManager.Events.Models;
using ExpensesManager.Events.Publishers;
using ExpensesManager.Events.Templates;

namespace ExpensesManager.Application.BusinessRules.UserBusinessRule
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

        private readonly IWorkUnit _workUnit;

        private readonly PasswordEncryption _passwordEncryption;

        private readonly IMessagePublisher _messagePublisher;

        public CreateUser(IUserWriteOnlyRepository userWriteOnlyRepository, IWorkUnit workUnit, PasswordEncryption passwordEncryption, IMessagePublisher messagePublisher)
        {
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _workUnit = workUnit;
            _passwordEncryption = passwordEncryption;
            _messagePublisher = messagePublisher;
        }

        public async Task Execute(User user)
        {
            user.Salt = Guid.NewGuid().ToString().Replace("-", "");

            user.Password = _passwordEncryption.Encrypt(user.Password, user.Salt);

            await _userWriteOnlyRepository.Add(user);

            _messagePublisher.Publish<CreateUserMailModel>(
                new CreateUserMailModel { MailTo = user.Mail, Subject = MailTemplates.SUBJECT_CREATE_USER, Template = MailTemplates.TEMPLATE_CREATE_USER, UserName = user.Name },
                RabbitMQQueues.CreateUserExchange,
                RabbitMQQueues.CreateUserRouting,
                RabbitMQQueues.CreateUserQueue
                );

            await _workUnit.Commit();
        }
    }
}
