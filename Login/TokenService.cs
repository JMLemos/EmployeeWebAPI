using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using EmployeeWebApi.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace EmployeeWebApi.Login
{
    public class TokenService : ITokenService
    {
                
        public Task<string> ConstruirToken()
        {
            return Task.Run(() =>
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(ServerSecret.Secret);
                
                var tokenDescriptor = new SecurityTokenDescriptor()
                {

                    Issuer = "joaolemos",
                    Expires = DateTime.UtcNow.AddHours(2),
                    Subject = new ClaimsIdentity(new[]{
                        new Claim(ClaimTypes.Name, "EmployeeApi"), 
                        new Claim("Module", "Web III .net") }),
                    Audience = "ada",
                    SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature )
                    

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);


                return tokenHandler.WriteToken(token);
            });
        }
    }
}
