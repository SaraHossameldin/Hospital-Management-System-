using HMS.Login_Story;

namespace HMS.Receptionist_Not_Completed
{
    public class Receptionist
    {
        public int ReceptionistID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public StaffStatus Status { get; set; } = StaffStatus.Inactive;
    }
}

