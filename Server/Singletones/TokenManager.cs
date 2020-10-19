using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Models;
using Newtonsoft.Json;

namespace Server.Singletones
{
    public class TokenManager
    {
        static string SecretKey = "1Z@mHA2sXnSyi~?M7Wx?xE9uStWCJmv8rA*UZ~yL}i~zG2GQULdQ*#~c?M?9{8BxH4Xi9yh?Y@gt~x~S%L87|7*R1AgRSzNeE|r";
        public static string GenerateToken(Account prs)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));//Формирование ключа
            
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, prs.Email),
                    new Claim(ClaimTypes.Name, prs.Name), 
                })
            };
            
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken sectoken = handler.CreateJwtSecurityToken(descriptor);
            string token = handler.WriteToken(sectoken);
  
            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                
                byte[] key = Encoding.ASCII.GetBytes(SecretKey);

                TokenValidationParameters parameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                SecurityToken securityToken;

                ClaimsPrincipal principal = handler.ValidateToken(token, parameters, out securityToken);

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}