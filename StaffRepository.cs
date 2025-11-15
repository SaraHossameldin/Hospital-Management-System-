using HMS.Admin_Functionalities;
using HMS.Login_Story;
using MySql.Data.MySqlClient;

public class StaffRepository : IStaffRepository
{
    private readonly string _connStr;

    public StaffRepository(string connStr)
    {
        _connStr = connStr;
    }

    public IEnumerable<Staff> GetAll()
    {
        var list = new List<Staff>();

        using var conn = new MySqlConnection(_connStr);
        conn.Open();

        string sql = "SELECT * FROM Staff";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Staff
            {
                StaffID = reader.GetInt32("StaffID"),
                Username = reader.GetString("Username"),
                PasswordHash = reader.GetString("Password"),  // <-- Fixed
                Role = Enum.Parse<Role>(reader.GetString("Role")),
                Status = Enum.Parse<StaffStatus>(reader.GetString("Status"))
            });
        }

        return list;
    }

    public Staff? GetById(int id)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();

        string sql = "SELECT * FROM Staff WHERE StaffID = @id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);

        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Staff
            {
                StaffID = reader.GetInt32("StaffID"),
                Username = reader.GetString("Username"),
                PasswordHash = reader.GetString("Password"), // <-- Fixed
                Role = Enum.Parse<Role>(reader.GetString("Role")),
                Status = Enum.Parse<StaffStatus>(reader.GetString("Status"))
            };
        }

        return null;
    }

    public Staff? GetByUsername(string username)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();

        string sql = "SELECT * FROM Staff WHERE Username = @u";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@u", username);

        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return new Staff
            {
                StaffID = reader.GetInt32("StaffID"),
                Username = reader.GetString("Username"),
                PasswordHash = reader.GetString("Password"), // <-- Fixed
                Role = Enum.Parse<Role>(reader.GetString("Role")),
                Status = Enum.Parse<StaffStatus>(reader.GetString("Status"))
            };
        }

        return null;
    }

    public void Add(Staff staff)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();

        string sql = @"INSERT INTO Staff (Username, Password, Role, Status)
                       VALUES (@u, @p, @r, @s)";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@u", staff.Username);
        cmd.Parameters.AddWithValue("@p", staff.PasswordHash); // <-- Fixed
        cmd.Parameters.AddWithValue("@r", staff.Role.ToString());
        cmd.Parameters.AddWithValue("@s", staff.Status.ToString());

        cmd.ExecuteNonQuery();
    }

    public void Update(Staff staff)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();

        string sql = @"UPDATE Staff SET Username=@u, Password=@p, Role=@r, Status=@s
                       WHERE StaffID=@id";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@u", staff.Username);
        cmd.Parameters.AddWithValue("@p", staff.PasswordHash); // <-- Fixed
        cmd.Parameters.AddWithValue("@r", staff.Role.ToString());
        cmd.Parameters.AddWithValue("@s", staff.Status.ToString());
        cmd.Parameters.AddWithValue("@id", staff.StaffID);

        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();

        string sql = "DELETE FROM Staff WHERE StaffID=@id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }
}
