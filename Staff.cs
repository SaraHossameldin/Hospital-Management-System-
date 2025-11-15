using HMS.Login_Story;

namespace HMS.Admin_Functionalities
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public Role Role { get; set; }
        public StaffStatus Status { get; set; } = StaffStatus.Inactive;
    }
}

