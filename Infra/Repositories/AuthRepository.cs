using Domain.Models.Out;
using Domain.Repositories;
using Domain.Base;
using Infra.Configs;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infra.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IUsersRepository _usersRepository;

        public AuthRepository(IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;
        }

        public JwtAuthResponse? Authenticate(string userName, string password)
        {
            Users user = _usersRepository.GetUserByUserName(userName);

            if(user == null)
                return null;

            bool validPassWord = new Hash().DecryptString(password, user.Password);

            if (!validPassWord)
                return null;

            var token = "";

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JwtEnv.JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JwtEnv.JWT_SECURITY_KEY);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            try
            {
                var securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
                token = jwtSecurityTokenHandler.WriteToken(securityToken);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            

            return new JwtAuthResponse
            {
                token = token,
            };
        }
    }
}
