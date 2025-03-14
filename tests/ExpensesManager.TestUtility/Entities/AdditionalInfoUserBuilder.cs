using Bogus;
using ExpensesManager.Domain.Entities;

namespace ExpensesManager.TestUtility.Entities
{
    public class AdditionalInfoUserBuilder
    {
        public static AdditionalInfoUser GenerateAdditionalInfoUser()
        {
            AdditionalInfoUser additionalInfoUser = new Faker<AdditionalInfoUser>()
                .RuleFor(r => r.Id, _ => 1)
                .RuleFor(r => r.BirthDate, _ => DateTime.Today.AddYears(-15))
                .RuleFor(r => r.Gender, _ => Domain.Enum.GenderType.Male)
                .RuleFor(r => r.Phone, f => f.Phone.PhoneNumber("(##) #####-####"))
                .RuleFor(r => r.Nationality, f => f.Address.CountryCode())
                .RuleFor(r => r.Occupation, f => f.Person.Website);

            return additionalInfoUser;
        }
    }
}
