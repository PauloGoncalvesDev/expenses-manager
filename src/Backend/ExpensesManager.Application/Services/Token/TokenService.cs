using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExpensesManager.Application.Services.Token
{
    public class TokenService
    {
        private readonly string _emailAlias = "eml";

        private readonly string _secretJwtPassword;

        private readonly double _expirationTimeJwt;

        public TokenService(string secretJwtPassword, double expirationTimeJwt)
        {
            _secretJwtPassword = secretJwtPassword;
            _expirationTimeJwt = expirationTimeJwt;
        }

        public string GenerateTokenJwt(string userMail)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(_emailAlias, userMail)
            };

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_expirationTimeJwt),
                SigningCredentials = new SigningCredentials(SymmetricKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler JwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = JwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return JwtSecurityTokenHandler.WriteToken(securityToken);
        }

        public ClaimsPrincipal ValidateTokenJwt(string tokenJwt)
        {
            JwtSecurityTokenHandler JwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                IssuerSigningKey = SymmetricKey(),
                ClockSkew = new TimeSpan(0),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            ClaimsPrincipal claimsPrincipal = JwtSecurityTokenHandler.ValidateToken(tokenJwt, validationParameters, out _);

            return claimsPrincipal;
        }

        public void SaveTokenOnCookie(HttpResponse response, string tokenJwt)
        {
            response.Cookies.Append("token_expensemanager_auth", tokenJwt,
                    new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddHours(_expirationTimeJwt),
                        HttpOnly = true,
                        Secure = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.None
                    });
        }

        public void DeleteCookie(HttpResponse response)
        {
            response.Cookies.Delete("token_expensemanager_auth",
                    new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        IsEssential = true,
                        SameSite = SameSiteMode.None
                    });
        }

        public string GetEmailFromTokenJwt(string tokenJwt)
        {
            ClaimsPrincipal claimsPrincipal = ValidateTokenJwt(tokenJwt);

            return claimsPrincipal.FindFirst(_emailAlias).Value;
        }

        private SymmetricSecurityKey SymmetricKey()
        {
            byte[] symmetricKey = Convert.FromBase64String(_secretJwtPassword);

            return new SymmetricSecurityKey(symmetricKey);
        }
    }
}
