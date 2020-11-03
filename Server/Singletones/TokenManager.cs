using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.Linq;
using Models.Account;
using Newtonsoft.Json;
using Server;

namespace Server.Singletones
{
    public class TokenManager
    {
        static string SecretKey = "1Z@mHA2sXnSyi~?M7Wx?xE9uStWCJmv8rA*UZ~yL}i~zG2GQULdQ*#~c?M?9{8BxH4Xi9yh?Y@gt~x~S%L87|7*R1AgRSzNeE|r";

        public static string GenerateToken(AuthorizationModel model) //Написать нормальную конфигурацию
        {
            var credintials = new SigningCredentials(new SymmetricSecurityKey(Encoding.Unicode.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer:"CommerServer",
                audience: "CommerClient",
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim("Password", model.Password)
                },
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credintials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static Claim GetClaim(string tokenString, string type)
        {
            JwtSecurityToken token = (JwtSecurityToken) new JwtSecurityTokenHandler().ReadToken(tokenString);
            Claim claim = token.Claims.FirstOrDefault(t => t.Type == type);
            return claim;
        }
    }
}