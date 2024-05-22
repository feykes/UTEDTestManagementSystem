using TestManagementSystem.Domain.Entities.Identity;

namespace TestManagementSystem.Application.Abstractions
{
    public interface ITokenHandler
    {
        DTOs.Identity.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
