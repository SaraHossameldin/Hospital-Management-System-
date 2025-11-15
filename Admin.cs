namespace HMS.Admin_Functionalities
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
