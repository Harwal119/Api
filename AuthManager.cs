using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace batch15webAPI;

public class AuthManager : IAuthManager
{
    private readonly string _key;

    public AuthManager(string key)
    {
        _key = key;
    }

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role , user.Role),
                new Claim(ClaimTypes.Email, user.Email)
            };
            // foreach(var role in user.Roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role, role.Name));
            // }

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key)), 
                    SecurityAlgorithms.HmacSha256Signature),
                    Issuer = "Ade"
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);

            return tokenHandler.WriteToken(token);
    }
}