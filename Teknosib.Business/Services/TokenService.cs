using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.TokenDto;
using Teknosib.Business.Interface;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;
        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
        }

        public TokensDto CreateTokens(AppUser user)
        {
            var access = CreateAccessToken(user);
            var refresh = CreateRefreshToken();

            return new TokensDto { AccessToken = access, RefreshToken = refresh };
        }

        private string CreateAccessToken(AppUser user)
        {

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId ,user.AppUserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email ,user.Email),
                new Claim("role",user.Role.ToString())

            }; 
            

            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = creds,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);


        }
        
        private string CreateRefreshToken()
        {
            var randomnumber = new Byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomnumber); ;
            return Convert.ToBase64String(randomnumber);
        }

        

        
    }
}
