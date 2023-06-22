using Domain.Entities;
using Domain.Models.In;
using Domain.Models.Out;

namespace Application.UseCases.Interfaces
{
    public interface IUsersUseCases
    {
        Users GetUserByUserName(string userName);

        Users Register(UserRegisterRequest userRegisterRequest);
    }
}