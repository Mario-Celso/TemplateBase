using Application.UseCases.Interfaces;
using Domain.Entities;
using Domain.Models.In;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UsersUseCases : IUsersUseCases
    {
        private readonly IUsersRepository _usersRepository;

        public UsersUseCases(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public Users GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Users Register(UserRegisterRequest userRegisterRequest)
        {
            return _usersRepository.Register(userRegisterRequest);
        }
    }
}
