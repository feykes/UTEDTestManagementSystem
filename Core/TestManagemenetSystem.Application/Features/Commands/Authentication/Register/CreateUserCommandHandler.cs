using MediatR;
using TestManagementSystem.Application.Abstractions;
using TestManagementSystem.Application.DTOs.Identity.User;

namespace TestManagementSystem.Application.Features.Commands.Authentication.Register
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponseDTO response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Name = request.Name,
                SurName = request.Surname,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.Username,
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}