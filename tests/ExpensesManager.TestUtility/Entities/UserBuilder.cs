using Bogus;
using ExpensesManager.Domain.Entities;
using ExpensesManager.TestUtility.Cryptography;

namespace ExpensesManager.TestUtility.Entities
{
    public class UserBuilder
    {
        public static (User user, string password) GenerateUser()
        {
            string password = string.Empty, salt = string.Empty;

            User user = new Faker<User>()
                .RuleFor(r => r.Id, _ => 1)
                .RuleFor(r => r.Name, b => b.Person.FullName)
                .RuleFor(r => r.Mail, b => b.Person.Email)
                .RuleFor(r => r.Salt, b =>
                {
                    salt = b.Random.String2(16, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");

                    return salt;
                })
                .RuleFor(r => r.Password, b =>
                {
                    password = PasswordEncryptionBuilder.GenerateStrongPassword();

                    return password;
                });

            return (user, password);
        }
    }
}
