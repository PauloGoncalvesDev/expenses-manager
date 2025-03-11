using Bogus;
using ExpensesManager.Application.Services.Cryptography;

namespace ExpensesManager.TestUtility.Cryptography
{
    public class PasswordEncryptionBuilder
    {
        public static string GenerateEncryptedPassword(string password, string salt)
        {
            return new PasswordEncryption().Encrypt(password, salt);
        }

        public static string GenerateStrongPassword()
        {
            Faker faker = new Faker();

            return $"{faker.Random.Char('A', 'Z')}" +
                   $"{faker.Random.Char('a', 'z')}" + 
                   $"{faker.Random.Char('0', '9')}" +
                   $"{faker.PickRandom("@$!%*?&.")}" +
                   $"{faker.Random.String2(10)}";
        }
    }
}
