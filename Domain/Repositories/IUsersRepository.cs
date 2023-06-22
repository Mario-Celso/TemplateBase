using Domain.Entities;
using Domain.Models.In;
using Domain.Models.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsersRepository
    {
        Users GetUserByUserName(string username);
        Users Register(UserRegisterRequest userRegisterRequest);
    }
}
