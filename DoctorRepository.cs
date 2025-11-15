using HMS.Doctor_Functionalities;
using HMS.Login_Story;
using MySql.Data.MySqlClient;

public class DoctorRepository : IDoctorRepository
{
    private readonly string _connStr;
    public DoctorRepository(string connStr) => _connStr = connStr;

    public void Add(Doctor d)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand(
            @"INSERT INTO Doctors (FirstName, LastName, Specialization, Email, Status)
              VALUES (@fn, @ln, @dept, @email, @status)", conn);
        cmd.Parameters.AddWithValue("@fn", d.FirstName);
        cmd.Parameters.AddWithValue("@ln", d.LastName);
        cmd.Parameters.AddWithValue("@dept", d.Department);
        cmd.Parameters.AddWithValue("@email", d.Email);
        cmd.Parameters.AddWithValue("@status", d.Status.ToString());
        cmd.ExecuteNonQuery();
    }

    //public Doctor? GetByUsername(string username)
    //{
    //    using var conn = new MySqlConnection(_connStr);
    //    conn.Open();
    //    var cmd = new MySqlCommand("SELECT * FROM Doctors WHERE CONCAT(FirstName,' ',LastName)=@username", conn);
    //    cmd.Parameters.AddWithValue("@username", username);

    //    using var reader = cmd.ExecuteReader();
    //    if (!reader.Read()) return null;

    //    return new Doctor
    //    {
    //        DoctorID = Convert.ToInt32(reader["DoctorID"]),
    //        FirstName = reader["FirstName"].ToString()!,
    //        LastName = reader["LastName"].ToString()!,
    //        Department = reader["Specialization"].ToString()!,
    //        Email = reader["Email"].ToString()!,
    //        Status = reader["Status"].ToString() == "Active" ? StaffStatus.Active : StaffStatus.Inactive
    //    };
    //}
    public Doctor? GetByUsername(string username)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand("SELECT * FROM Doctors WHERE Username=@username", conn); // <-- changed here
        cmd.Parameters.AddWithValue("@username", username);

        using var reader = cmd.ExecuteReader();
        if (!reader.Read()) return null;

        return new Doctor
        {
            DoctorID = Convert.ToInt32(reader["DoctorID"]),
            FirstName = reader["FirstName"].ToString()!,
            LastName = reader["LastName"].ToString()!,
            Username = reader["Username"].ToString()!,  // add Username property
            Department = reader["Specialization"].ToString()!,
            Email = reader["Email"].ToString()!,
            Status = reader["Status"].ToString() == "Active" ? StaffStatus.Active : StaffStatus.Inactive
        };
    }

    public IEnumerable<Doctor> GetAll()
    {
        var list = new List<Doctor>();
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand("SELECT * FROM Doctors", conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Doctor
            {
                DoctorID = Convert.ToInt32(reader["DoctorID"]),
                FirstName = reader["FirstName"].ToString()!,
                LastName = reader["LastName"].ToString()!,
                Department = reader["Specialization"].ToString()!,
                Email = reader["Email"].ToString()!,
                Status = reader["Status"].ToString() == "Active" ? StaffStatus.Active : StaffStatus.Inactive
            });
        }
        return list;
    }

    public void UpdateStatus(int doctorId, StaffStatus status)
    {
        using var conn = new MySqlConnection(_connStr);
        conn.Open();
        var cmd = new MySqlCommand("UPDATE Doctors SET Status=@status WHERE DoctorID=@id", conn);
        cmd.Parameters.AddWithValue("@status", status.ToString());
        cmd.Parameters.AddWithValue("@id", doctorId);
        cmd.ExecuteNonQuery();
    }
}
