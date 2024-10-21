using ExpensesManager.Domain.Entities;
using ExpensesManager.Exceptions.Exceptions;
using ExpensesManager.Exceptions.ResourcesMessage;
using System.Text.RegularExpressions;

namespace ExpensesManager.Application.Validators
{
    public static class AdditionalInfoUserValidator
    {
        public static void Validate(AdditionalInfoUser additionalInfoUser)
        {
            ValidateOccupation(additionalInfoUser.Occupation);

            ValidateBirthDate(additionalInfoUser.BirthDate);

            ValidateNationality(additionalInfoUser.Nationality);

            ValidatePhone(additionalInfoUser.Phone);
        }

        private static void ValidatePhone(string phone)
        {
            if (!Regex.IsMatch(phone, @"^\(\d{2}\)\s\d{5}-\d{4}$"))
                throw new ValidationException(VALIDATIONMSG.INVALID_PHONE);
        }

        private static void ValidateNationality(string nationality)
        {
            if (Regex.IsMatch(nationality, @"^\d+$"))
                throw new ValidationException(VALIDATIONMSG.NATIONALITY_NUMBER);
        }

        private static void ValidateBirthDate(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            if (age < 13)
                throw new ValidationException(VALIDATIONMSG.BIRTHDATE_YEARS);
        }

        private static void ValidateOccupation(string occupation)
        {
            if (Regex.IsMatch(occupation, @"^\d+$"))
                throw new ValidationException(VALIDATIONMSG.OCCUPATION_NUMBER);
        }
    }
}
