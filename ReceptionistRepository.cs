using HMS.Login_Story;
using HMS.Receptionist_Not_Completed;
using MySql.Data.MySqlClient;

public class ReceptionistRepository : IReceptionistRepository
{
    private readonly string _connStr;
    public ReceptionistRepository(string connStr) => _connStr = connStr;

    public void Add(Receptionist r)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand(
            @"INSERT INTO Receptionists (FirstName, LastName, Email, Status)
              VALUES (@fn, @ln, @email, @status)", conn);
        cmd.Parameters.AddWithValue("@fn", r.FirstName);
        cmd.Parameters.AddWithValue("@ln", r.LastName);
        cmd.Parameters.AddWithValue("@email", r.Email);
        cmd.Parameters.AddWithValue("@status", r.Status.ToString());
        cmd.ExecuteNonQuery();
    }

    public Receptionist? GetByUsername(string username)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand("SELECT * FROM Receptionists WHERE CONCAT(FirstName,' ',LastName)=@username", conn);
        cmd.Parameters.AddWithValue("@username", username);

        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        return new Receptionist
        {
            ReceptionistID = Convert.ToInt32(reader["ReceptionistID"]),
            FirstName = reader["FirstName"].ToString()!,
            LastName = reader["LastName"].ToString()!,
            Email = reader["Email"].ToString()!,
            Status = reader["Status"].ToString() == "Active" ? StaffStatus.Active : StaffStatus.Inactive
        };
    }

    public IEnumerable<Receptionist> GetAll()
    {
        var list = new List<Receptionist>();
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand("SELECT * FROM Receptionists", conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Receptionist
            {
                ReceptionistID = Convert.ToInt32(reader["ReceptionistID"]),
                FirstName = reader["FirstName"].ToString()!,
                LastName = reader["LastName"].ToString()!,
                Email = reader["Email"].ToString()!,
                Status = reader["Status"].ToString() == "Active" ? StaffStatus.Active : StaffStatus.Inactive
            });
        }
        return list;
    }

    public void UpdateStatus(int receptionistId, StaffStatus status)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand("UPDATE Receptionists SET Status=@status WHERE ReceptionistID=@id", conn);
        cmd.Parameters.AddWithValue("@status", status.ToString());
        cmd.Parameters.AddWithValue("@id", receptionistId);
        cmd.ExecuteNonQuery();
    }
}
