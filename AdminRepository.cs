using MySql.Data.MySqlClient;

namespace HMS.Admin_Functionalities
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(string cs)
        {
            _connectionString = cs;
        }

        public Admin? GetByUsername(string username)
        {
            using var con = new MySqlConnection(_connectionString);
            con.Open();

            string sql = "SELECT * FROM Users WHERE Username=@username AND Role='Admin'"; // <-- changed table & filter
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new Admin
            {
                AdminID = Convert.ToInt32(r["UserID"]),
                Username = r["Username"].ToString()!,
                Email = r["Email"].ToString()!,
                PasswordHash = r["PasswordHash"].ToString()!,
                FirstName = r["Username"].ToString()!,  // optional if you only have Username
                LastName = r["Username"].ToString()!
            };
        }


        public void Add(Admin a)
        {
            using var con = new MySqlConnection(_connectionString);
            con.Open();

            string sql = @"INSERT INTO Admins
                (FirstName, LastName, Username, PasswordHash, Email)
                VALUES (@fn, @ln, @un, @ph, @em)";

            using var cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@fn", a.FirstName);
            cmd.Parameters.AddWithValue("@ln", a.LastName);
            cmd.Parameters.AddWithValue("@un", a.Username);
            cmd.Parameters.AddWithValue("@ph", a.PasswordHash);
            cmd.Parameters.AddWithValue("@em", a.Email);

            cmd.ExecuteNonQuery();
        }

        public IEnumerable<Admin> GetAll()
        {
            var list = new List<Admin>();

            using var con = new MySqlConnection(_connectionString);
            con.Open();

            string sql = "SELECT * FROM Admins";
            using var cmd = new MySqlCommand(sql, con);
            using var r = cmd.ExecuteReader();

            while (r.Read())
                list.Add(Map(r));

            return list;
        }

        private Admin Map(MySqlDataReader r)
        {
            return new Admin
            {
                AdminID = r.GetInt32("AdminID"),
                FirstName = r.GetString("FirstName"),
                LastName = r.GetString("LastName"),
                Username = r.GetString("Username"),
                PasswordHash = r.GetString("PasswordHash"),
                Email = r.GetString("Email")
            };
        }
    }
}
