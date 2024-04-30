using Microsoft.IdentityModel.Tokens;

using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmallBusinessApp.Server.Security
{
    public class JwtGenerator(IConfiguration configuration) : IJwtGenerator
    {
        private string CreateJwt(Customer customer)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, customer.EmailAddress)
            };

            var issuer = configuration.GetSection("JwtSettings:Issuer").Value;
            var audience = configuration.GetSection("JwtSettings:Audience").Value;
            var credentials = new SigningCredentials(new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration.GetSection("JwtSettings:Key").Value!)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string GetJwt(Customer customer)
        {
            return CreateJwt(customer);
        }
    }
}
