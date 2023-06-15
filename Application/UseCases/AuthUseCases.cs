using Application.UseCases.Interfaces;
using Domain.Models.Out;
using Domain.Repositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AuthUseCases : IAuthUseCases
    {
        private readonly IAuthRepository _authRepository;

        public AuthUseCases(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public JwtAuthResponse Authenticate(string userName, string password)
        {
            //validação
            
            return _authRepository.Authenticate(userName, password);
        }
    }
}
