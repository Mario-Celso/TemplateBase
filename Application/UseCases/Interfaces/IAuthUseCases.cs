using Domain.Models.Out;

namespace Application.UseCases.Interfaces
{
    public interface IAuthUseCases
    {
        JwtAuthResponse Authenticate(string userName, string password);
    }
}