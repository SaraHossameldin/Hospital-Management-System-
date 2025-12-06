using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HMS.Admin_Functionalities
{
    public class DoctorAvailabilityRepository : IDoctorAvailabilityRepository
    {
        private readonly string _connStr;

        public DoctorAvailabilityRepository(string connStr = "server=localhost;database=HMS_2;user=root;password=rrFFvv4$1!2@;")
        {
            _connStr = connStr;
        }

        public void Add(DoctorAvailability a)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO DoctorAvailability (DoctorID, StartAt, EndAt, IsAvailable)
                VALUES (@doc, @start, @end, @available);
                SELECT LAST_INSERT_ID();";
            cmd.Parameters.AddWithValue("@doc", a.DoctorID);
            cmd.Parameters.AddWithValue("@start", a.StartAt);
            cmd.Parameters.AddWithValue("@end", a.EndAt);
            cmd.Parameters.AddWithValue("@available", a.IsAvailable ? 1 : 0);
            a.AvailabilityID = Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Remove(int availabilityId)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE DoctorAvailability SET IsAvailable=0 WHERE AvailabilityID=@id";
            cmd.Parameters.AddWithValue("@id", availabilityId);
            cmd.ExecuteNonQuery();
        }

        public void Update(DoctorAvailability a)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE DoctorAvailability SET StartAt=@start, EndAt=@end, IsAvailable=@avail
                WHERE AvailabilityID=@id";
            cmd.Parameters.AddWithValue("@start", a.StartAt);
            cmd.Parameters.AddWithValue("@end", a.EndAt);
            cmd.Parameters.AddWithValue("@avail", a.IsAvailable ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", a.AvailabilityID);
            cmd.ExecuteNonQuery();
        }

        public DoctorAvailability? GetById(int id)
        {
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM DoctorAvailability WHERE AvailabilityID=@id";
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return Map(reader);
            return null;
        }

        // Unified: Get all slots for a doctor (regardless of date)
        public IEnumerable<DoctorAvailability> GetByDoctor(int doctorId)
        {
            var list = new List<DoctorAvailability>();
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM DoctorAvailability WHERE DoctorID=@doc";
            cmd.Parameters.AddWithValue("@doc", doctorId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(Map(reader));
            }
            return list;
        }

        public IEnumerable<DoctorAvailability> GetAvailableByDoctor(int doctorId)
        {
            var list = new List<DoctorAvailability>();
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM DoctorAvailability WHERE DoctorID=@doc AND IsAvailable=1";
            cmd.Parameters.AddWithValue("@doc", doctorId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(Map(reader));
            }
            return list;
        }

        public IEnumerable<DoctorAvailability> GetDoctorsWithAvailability()
        {
            var list = new List<DoctorAvailability>();
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM DoctorAvailability WHERE IsAvailable=1";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(Map(reader));
            }
            return list;
        }

        private static DoctorAvailability Map(MySqlDataReader r) => new DoctorAvailability
        {
            AvailabilityID = Convert.ToInt32(r["AvailabilityID"]),
            DoctorID = Convert.ToInt32(r["DoctorID"]),
            StartAt = Convert.ToDateTime(r["StartAt"]),
            EndAt = Convert.ToDateTime(r["EndAt"]),
            IsAvailable = Convert.ToInt32(r["IsAvailable"]) == 1,
            CreatedAt = r["CreatedAt"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedAt"])
        };
        public IEnumerable<DoctorAvailability> GetAllAvailable()
        {
            var list = new List<DoctorAvailability>();
            using var conn = new MySqlConnection(_connStr);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM DoctorAvailability WHERE IsDeleted=0";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }
    }
}
