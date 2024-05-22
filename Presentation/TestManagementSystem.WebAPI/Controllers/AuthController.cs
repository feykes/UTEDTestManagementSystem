using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestManagementSystem.Application.Features.Commands.Authentication.Login;
using TestManagementSystem.Application.Features.Commands.Authentication.Register;

namespace TestManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request) => Ok(await this.mediator.Send(request));
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommandRequest request) => Ok(await this.mediator.Send(request));

    }
}
