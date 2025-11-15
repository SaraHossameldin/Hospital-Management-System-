using HMS.Login_Story;

namespace HMS.Doctor_Functionalities
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Email { get; set; } = "";
        public string Department { get; set; } = "";
        public StaffStatus Status { get; set; } = StaffStatus.Inactive;
    }
}
