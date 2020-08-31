using BugTracker.Storing.Models;

namespace BugTracker.Storing.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public UserDTO() { }

        public UserDTO(Users user)
        {
            UserId = user.UserId;
            Role = user.Role.Name;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }
    }
}