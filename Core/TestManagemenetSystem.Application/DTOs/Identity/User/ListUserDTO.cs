namespace TestManagementSystem.Application.DTOs.Identity.User
{
    public class ListUserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public bool TwoFactorEnabled { get; set; }
    }
}
