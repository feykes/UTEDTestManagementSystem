namespace TestManagementSystem.Application.Abstractions
{
    public interface IAuthService
    {
        Task PasswordResetAsnyc(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
        Task<DTOs.Identity.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<DTOs.Identity.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
