namespace LabSoft.DTOs
{
    public class UserRequestDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set;}
    }
}