using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestManagementSystem.Application.Abstractions;
using TestManagementSystem.Application.DTOs.Identity.User;
using TestManagementSystem.Application.Exceptions;
using TestManagementSystem.Domain.Entities.Identity;

namespace TestManagementSystem.Persistence.Repositories.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public int TotalUsersCount => throw new NotImplementedException();

        public Task AssignRoleToUserAsnyc(string userId, string[] roles)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model)
        {
            IdentityResult result = await this.userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                UserName = model.Username,
                Email = model.Email,
                Name = model.Name,
                Surname = model.SurName
            }, model.Password);

            CreateUserResponseDTO response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task<List<ListUserDTO>> GetAllUsersAsync(int page, int size)
        {
            var users = await this.userManager.Users
                   .Skip(page * size)
                   .Take(size)
                   .ToListAsync();

            return users.Select(user => new ListUserDTO
            {
                Id = user.Id,
                Email = user.Email,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName

            }).ToList();
        }

        public async Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            AppUser user = await this.userManager.FindByIdAsync(userIdOrName);
            if (user == null)
                user = await this.userManager.FindByNameAsync(userIdOrName);

            if (user != null)
            {
                var userRoles = await this.userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            //AppUser user = await this.userManager.FindByIdAsync(userId);
            //if (user != null)
            //{
            //    resetToken = resetToken.UrlDecode();
            //    IdentityResult result = await this.userManager.ResetPasswordAsync(user, resetToken, newPassword);
            //    if (result.Succeeded)
            //        await this.userManager.UpdateSecurityStampAsync(user);
            //    else
            //        throw new PasswordChangeFailedException();
            //}
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await this.userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }
    }
}