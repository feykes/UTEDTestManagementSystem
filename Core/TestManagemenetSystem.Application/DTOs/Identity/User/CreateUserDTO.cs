﻿namespace TestManagementSystem.Application.DTOs.Identity.User
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
