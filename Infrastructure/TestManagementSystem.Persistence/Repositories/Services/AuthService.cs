using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestManagementSystem.Application.Abstractions;
using TestManagementSystem.Application.DTOs.Identity;
using TestManagementSystem.Application.Exceptions;
using TestManagementSystem.Domain.Entities.Identity;

namespace TestManagementSystem.Persistence.Repositories.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> signInManager;
        readonly ITokenHandler tokenHandler;
        readonly IUserService userService;


        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenHandler = tokenHandler;
            this.userService = userService;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            Domain.Entities.Identity.AppUser user = await this.userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await this.userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await this.signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) //Authentication başarılı!
            {
                Token token = this.tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await this.userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            throw new AuthenticationErrorException();
        }

        public async Task PasswordResetAsnyc(string email)
        {
            AppUser user = await this.userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await this.userManager.GeneratePasswordResetTokenAsync(user);

                //byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                //resetToken = WebEncoders.Base64UrlEncode(tokenBytes);
                //resetToken = resetToken.UrlEncode();

                //await _mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
            }

        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await this.userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = this.tokenHandler.CreateAccessToken(15, user);
                await this.userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            else
                throw new NotFoundUserException();
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            AppUser user = await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                //byte[] tokenBytes = WebEncoders.Base64UrlDecode(resetToken);
                //resetToken = Encoding.UTF8.GetString(tokenBytes);
                //resetToken = resetToken.UrlDecode();

                return await this.userManager.VerifyUserTokenAsync(user, this.userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }
      
    }
}
