using Domain.Models.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAuthRepository
    {
        JwtAuthResponse Authenticate(string userName, string password);
    }
}
