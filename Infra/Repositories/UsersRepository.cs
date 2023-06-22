using Domain.Base;
using Domain.Entities;
using Domain.Models.In;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApiDbContext _context;
        public UsersRepository(ApiDbContext context) 
        {
            _context = context;
        }

        public Users GetUserByUserName(string username)
        {
            try
            {
                Users user = _context.Users.FirstOrDefault(x => x.UserName == username);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Users Register(UserRegisterRequest userRegisterRequest)
        {
            try
            {
                Users registerUser = new Users(userRegisterRequest.Name, new Hash().CryptString(userRegisterRequest.Password), 0, userRegisterRequest.Email, userRegisterRequest.Cpf, userRegisterRequest.UserName);
                _context.Users.Add(registerUser);
                _context.SaveChanges();
                return registerUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
