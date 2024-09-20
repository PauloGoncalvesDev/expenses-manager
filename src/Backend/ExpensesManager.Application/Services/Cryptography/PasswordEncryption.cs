﻿using System.Security.Cryptography;
using System.Text;

namespace ExpensesManager.Application.Services.Cryptography
{
    public class PasswordEncryption
    {
        private readonly string _secretPassword;

        public PasswordEncryption(string internPassword)
        {
            _secretPassword = internPassword;
        }

        public string Encrypt(string password)
        {
            string passwordWithInternPassword = $"{password}{_secretPassword}";

            byte[] bytes = Encoding.UTF8.GetBytes(passwordWithInternPassword);

            var sha512 = SHA512.Create();

            byte[] hashBytes = sha512.ComputeHash(bytes);

            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] hashBytes)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hashBytes)
            {
                string hex = b.ToString("x2");
                stringBuilder.Append(hex);
            }

            return stringBuilder.ToString();
        }
    }
}
