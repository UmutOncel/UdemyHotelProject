using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate() 
        {
            //program.cs içindeki "IssuerSigningKey" ile burası aynı olmalı.
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapi");

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer: "http://localhost",
                    audience: "http://localhost",
                    notBefore: DateTime.Now,    //şu andan önce oluşturulacak
                    expires: DateTime.Now.AddSeconds(20),    //token'ın geçerlilik süresi (20 sn)
                    signingCredentials: credentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        public string TokenCreateAdmin() 
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapiaspnetcoreapi");

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //rolleri "Claim" içinde oluşturuyoruz.
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),    //Id oluşturmaya benzer.
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Visitor")
            };

            JwtSecurityToken token = new JwtSecurityToken
                (
                    audience: "http://localhost",
                    issuer: "http://localhost",
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddSeconds(20),
                    signingCredentials: credentials,
                    claims: claims
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
