using ChatApp.Services.Models.JwtModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.Services.Helpers;

public static class JwtTokenHelper
{
    public static string GenerateToken(TokenModel tokenModel)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, tokenModel.UserName),
            new Claim(ClaimTypes.Role, tokenModel.Role),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenModel.SigninKey));
        var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken(
            issuer:tokenModel.Issuer,
            audience: tokenModel.Audience, 
            claims: claims, 
            expires: DateTime.Now.AddHours(24), 
            signingCredentials: credentials,
            notBefore: DateTime.Now
        );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        return token;
    }
}
