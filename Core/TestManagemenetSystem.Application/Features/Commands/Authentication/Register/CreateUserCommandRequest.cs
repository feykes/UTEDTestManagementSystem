﻿using MediatR;

namespace TestManagementSystem.Application.Features.Commands.Authentication.Register
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
