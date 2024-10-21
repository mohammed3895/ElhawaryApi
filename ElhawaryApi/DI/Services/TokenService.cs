using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ElhawaryApi.DI.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;
        public string CreateToken(IdentityUser user, List<string> roles)
        {
            string keyString = _configuration["Jwt:Key"]!;
            string issuerString = _configuration["Jwt:Issuer"]!;
            string audienceString = _configuration["Jwt:Audience"]!;

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email!)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString!))
                ?? throw new Exception("missing secret key");

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuerString,
                    audienceString,
                    claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
