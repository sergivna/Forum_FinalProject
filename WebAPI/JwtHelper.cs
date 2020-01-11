using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace WebAPI
{
    public static class JwtHelper
    {
        public const string JwtCookieName = "AngularCourse.Jwt";

        public const string Audience = "http://localhost:4200";

        public const string Issuer = "http://localhost:44354";

        public static string HashKey = Guid.NewGuid().ToString();

        public static TimeSpan TokenLifetTime = TimeSpan.FromHours(1);

        public const string HashAlgorithm = SecurityAlgorithms.HmacSha256;

        public static SigningCredentials CreateCredentials()
        {
            string key = HashKey;

            byte[] bytes = Encoding.UTF8.GetBytes(key);
            var secret = Convert.ToBase64String(bytes);

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secret));
            return new SigningCredentials(
                securityKey,
                HashAlgorithm);
        }
    }
}