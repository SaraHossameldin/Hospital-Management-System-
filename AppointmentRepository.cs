using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HMS.Admin_Functionalities
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly string _connStr;

        public AppointmentRepository(string connStr = "server=localhost;database=HMS_2;user=root;password=rrFFvv4$1!2@;")
        {
            _connStr = connStr;
        }

        public int Add(Appointment appt)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var trans = conn.BeginTransaction();
            using var cmd = conn.CreateCommand();
            cmd.Transaction = trans;

            // Check for conflicts
            cmd.CommandText = @"
                SELECT COUNT(*) FROM Appointment
                WHERE DoctorID=@doc
                  AND Status='Booked'
                  AND NOT (EndAt <= @start OR StartAt >= @end)";
            cmd.Parameters.AddWithValue("@doc", appt.DoctorID);
            cmd.Parameters.AddWithValue("@start", appt.StartAt);
            cmd.Parameters.AddWithValue("@end", appt.EndAt);

            var count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                trans.Rollback();
                throw new InvalidOperationException("Time slot is already taken.");
            }

            cmd.Parameters.Clear();
            cmd.CommandText = @"
                INSERT INTO Appointment (PatientID, DoctorID, StartAt, EndAt, Status)
                VALUES (@pat, @doc, @start, @end, @status);
                SELECT LAST_INSERT_ID();";
            cmd.Parameters.AddWithValue("@pat", appt.PatientID);
            cmd.Parameters.AddWithValue("@doc", appt.DoctorID);
            cmd.Parameters.AddWithValue("@start", appt.StartAt);
            cmd.Parameters.AddWithValue("@end", appt.EndAt);
            cmd.Parameters.AddWithValue("@status", appt.Status);

            var id = Convert.ToInt32(cmd.ExecuteScalar());
            trans.Commit();
            return id;
        }

        public void Update(Appointment appt)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Appointment 
                SET StartAt=@start, EndAt=@end, Status=@status
                WHERE AppointmentID=@id";
            cmd.Parameters.AddWithValue("@start", appt.StartAt);
            cmd.Parameters.AddWithValue("@end", appt.EndAt);
            cmd.Parameters.AddWithValue("@status", appt.Status);
            cmd.Parameters.AddWithValue("@id", appt.AppointmentID);
            cmd.ExecuteNonQuery();
        }

        public void Cancel(int appointmentId)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Appointment SET Status='Cancelled' WHERE AppointmentID=@id";
            cmd.Parameters.AddWithValue("@id", appointmentId);
            cmd.ExecuteNonQuery();
        }

        public Appointment? GetById(int id)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Appointment WHERE AppointmentID=@id";
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return Map(reader);
            }
            return null;
        }

        public IEnumerable<Appointment> GetByDoctor(int doctorId, DateTime from, DateTime to)
        {
            var list = new List<Appointment>();
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT * FROM Appointment
                WHERE DoctorID=@doc
                  AND NOT (EndAt <= @from OR StartAt >= @to)
                  AND Status='Booked'";
            cmd.Parameters.AddWithValue("@doc", doctorId);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(Map(reader));
            return list;
        }

        public IEnumerable<Appointment> GetByPatient(int patientId)
        {
            var list = new List<Appointment>();
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Appointment WHERE PatientID=@pid ORDER BY StartAt DESC";
            cmd.Parameters.AddWithValue("@pid", patientId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(Map(reader));
            return list;
        }

        private static Appointment Map(MySqlDataReader r) => new Appointment
        {
            AppointmentID = Convert.ToInt32(r["AppointmentID"]),
            PatientID = Convert.ToInt32(r["PatientID"]),
            DoctorID = Convert.ToInt32(r["DoctorID"]),
            StartAt = Convert.ToDateTime(r["StartAt"]),
            EndAt = Convert.ToDateTime(r["EndAt"]),
            Status = r["Status"].ToString() ?? "Booked",
            CreatedAt = r["CreatedAt"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedAt"])
        };
    }
}

