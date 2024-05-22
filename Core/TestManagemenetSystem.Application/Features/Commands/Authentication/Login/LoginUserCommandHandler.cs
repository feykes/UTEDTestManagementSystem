using MediatR;
using TestManagementSystem.Application.Abstractions;

namespace TestManagementSystem.Application.Features.Commands.Authentication.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService authService;
        public LoginUserCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await this.authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}