using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HospitalCRUD
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=localhost;Database=Hospital_Mangemt_system;Uid=root;Pwd=159201s159201;";
        
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        
        public bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    Console.WriteLine("Database connection successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }
    }

    // PATIENT REPOSITORY
    public class PatientRepository
    {
        private DatabaseHelper dbHelper;
        
        public PatientRepository() => dbHelper = new DatabaseHelper();
        
        public bool AddPatient(string firstName, string lastName, DateTime dateOfBirth, 
                              string gender, string phoneNumber, string email, 
                              string address, string bloodGroup)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Patients 
                                    (FirstName, LastName, DateOfBirth, Gender, PhoneNumber, Email, Address, BloodGroup) 
                                    VALUES (@firstName, @lastName, @dob, @gender, @phone, @email, @address, @bloodGroup)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@dob", dateOfBirth.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@gender", ValidateGender(gender));
                        command.Parameters.AddWithValue("@phone", phoneNumber ?? "");
                        command.Parameters.AddWithValue("@email", email ?? "");
                        command.Parameters.AddWithValue("@address", address ?? "");
                        command.Parameters.AddWithValue("@bloodGroup", bloodGroup ?? "");
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"✅ Patient {firstName} {lastName} added successfully!");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding patient: {ex.Message}");
                return false;
            }
        }
        
        public void GetAllPatients()
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Patients ORDER BY FirstName, LastName";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No patients found in the database.");
                            return;
                        }

                        Console.WriteLine("\n=== ALL PATIENTS ===");
                        Console.WriteLine("ID | Name | Gender | Phone | Email");
                        Console.WriteLine("-----------------------------------");
                        
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["PatientID"]} | {reader["FirstName"]} {reader["LastName"]} | {reader["Gender"]} | {reader["PhoneNumber"]} | {reader["Email"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading patients: {ex.Message}");
            }
        }
        
        public bool PatientExists(int patientId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Patients WHERE PatientID = @patientId";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        return Convert.ToInt32(command.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking patient: {ex.Message}");
                return false;
            }
        }
        
        public void GetPatientById(int patientId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Patients WHERE PatientID = @patientId";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Console.WriteLine($"\n=== PATIENT DETAILS ===");
                                Console.WriteLine($"ID: {reader["PatientID"]}");
                                Console.WriteLine($"Name: {reader["FirstName"]} {reader["LastName"]}");
                                Console.WriteLine($"DOB: {reader["DateOfBirth"]:yyyy-MM-dd}");
                                Console.WriteLine($"Gender: {reader["Gender"]}");
                                Console.WriteLine($"Phone: {reader["PhoneNumber"]}");
                                Console.WriteLine($"Email: {reader["Email"]}");
                                Console.WriteLine($"Address: {reader["Address"]}");
                                Console.WriteLine($"Blood Group: {reader["BloodGroup"]}");
                                Console.WriteLine($"Registered: {reader["CreatedAt"]}");
                            }
                            else
                            {
                                Console.WriteLine("Patient not found!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting patient: {ex.Message}");
            }
        }
        
        public bool UpdatePatient(int patientId, string firstName, string lastName, DateTime dateOfBirth,
                                 string gender, string phoneNumber, string email, string address, string bloodGroup)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"UPDATE Patients SET 
                                    FirstName = @firstName, LastName = @lastName, DateOfBirth = @dob,
                                    Gender = @gender, PhoneNumber = @phone, Email = @email,
                                    Address = @address, BloodGroup = @bloodGroup
                                    WHERE PatientID = @patientId";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@dob", dateOfBirth.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@gender", ValidateGender(gender));
                        command.Parameters.AddWithValue("@phone", phoneNumber ?? "");
                        command.Parameters.AddWithValue("@email", email ?? "");
                        command.Parameters.AddWithValue("@address", address ?? "");
                        command.Parameters.AddWithValue("@bloodGroup", bloodGroup ?? "");
                        command.Parameters.AddWithValue("@patientId", patientId);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Patient {patientId} updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Patient not found!");
                        }
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating patient: {ex.Message}");
                return false;
            }
        }
        
        public bool DeletePatient(int patientId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Patients WHERE PatientID = @patientId";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Patient {patientId} deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Patient not found!");
                        }
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting patient: {ex.Message}");
                return false;
            }
        }
        
        public void SearchPatients(string searchTerm)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT * FROM Patients 
                                    WHERE FirstName LIKE @search OR LastName LIKE @search 
                                    ORDER BY FirstName, LastName";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@search", $"%{searchTerm}%");
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine($"No patients found matching '{searchTerm}'");
                                return;
                            }

                            Console.WriteLine($"\n=== SEARCH RESULTS for '{searchTerm}' ===");
                            Console.WriteLine("ID | Name | Gender | Phone | Email");
                            Console.WriteLine("-----------------------------------");
                            
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["PatientID"]} | {reader["FirstName"]} {reader["LastName"]} | {reader["Gender"]} | {reader["PhoneNumber"]} | {reader["Email"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching patients: {ex.Message}");
            }
        }
        
        private string ValidateGender(string gender)
        {
            if (string.IsNullOrEmpty(gender)) return "Other";
            
            gender = gender.ToLower();
            return gender switch
            {
                "male" or "m" => "Male",
                "female" or "f" or "femal" => "Female", // Handles typo
                "other" or "o" => "Other",
                _ => "Other" // Default if invalid
            };
        }
    }

    // DOCTOR REPOSITORY
    public class DoctorRepository
    {
        private DatabaseHelper dbHelper;
        public DoctorRepository() => dbHelper = new DatabaseHelper();
        
        public bool AddDoctor(string firstName, string lastName, string specialization,
                            string phoneNumber, string email, string licenseNumber, decimal consultationFee)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Doctors 
                                    (FirstName, LastName, Specialization, PhoneNumber, Email, LicenseNumber, ConsultationFee) 
                                    VALUES (@firstName, @lastName, @specialization, @phone, @email, @license, @fee)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@specialization", specialization ?? "");
                        command.Parameters.AddWithValue("@phone", phoneNumber ?? "");
                        command.Parameters.AddWithValue("@email", email ?? "");
                        command.Parameters.AddWithValue("@license", licenseNumber);
                        command.Parameters.AddWithValue("@fee", consultationFee);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Dr. {firstName} {lastName} added successfully!");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding doctor: {ex.Message}");
                return false;
            }
        }
        
        public void GetAllDoctors()
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Doctors ORDER BY FirstName, LastName";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No doctors found in the database.");
                            return;
                        }

                        Console.WriteLine("\n=== ALL DOCTORS ===");
                        Console.WriteLine("ID | Name | Specialization | Phone | Status | Fee");
                        Console.WriteLine("-----------------------------------------------------");
                        
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["DoctorID"]} | Dr. {reader["FirstName"]} {reader["LastName"]} | {reader["Specialization"]} | {reader["PhoneNumber"]} | {reader["Status"]} | ${reader["ConsultationFee"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading doctors: {ex.Message}");
            }
        }
        
        public bool DoctorExists(int doctorId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Doctors WHERE DoctorID = @doctorId";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@doctorId", doctorId);
                        return Convert.ToInt32(command.ExecuteScalar()) > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking doctor: {ex.Message}");
                return false;
            }
        }
        
        public void GetActiveDoctors()
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Doctors WHERE Status = 'Active' ORDER BY FirstName, LastName";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No active doctors found.");
                            return;
                        }

                        Console.WriteLine("\n=== ACTIVE DOCTORS ===");
                        Console.WriteLine("ID | Name | Specialization | Fee");
                        Console.WriteLine("----------------------------------");
                        
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["DoctorID"]} | Dr. {reader["FirstName"]} {reader["LastName"]} | {reader["Specialization"]} | ${reader["ConsultationFee"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading active doctors: {ex.Message}");
            }
        }
        
        public bool UpdateDoctorStatus(int doctorId, string status, DateTime? leftDate = null)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Doctors SET Status = @status, LeftDate = @leftDate WHERE DoctorID = @doctorId";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status", ValidateStatus(status));
                        command.Parameters.AddWithValue("@leftDate", leftDate?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@doctorId", doctorId);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Doctor {doctorId} status updated to {status}!");
                        }
                        else
                        {
                            Console.WriteLine("Doctor not found!");
                        }
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating doctor status: {ex.Message}");
                return false;
            }
        }
        
        private string ValidateStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) return "Active";
            
            status = status.ToLower();
            return status switch
            {
                "active" or "a" => "Active",
                "inactive" or "i" => "Inactive",
                "left" or "l" => "Left",
                _ => "Active" // Default if invalid
            };
        }
    }

    // APPOINTMENT REPOSITORY
    public class AppointmentRepository
    {
        private DatabaseHelper dbHelper;
        public AppointmentRepository() => dbHelper = new DatabaseHelper();
        
        public bool ScheduleAppointment(int patientId, int doctorId, DateTime appointmentDate, string reason)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Appointments 
                                    (PatientID, DoctorID, AppointmentDate, Reason) 
                                    VALUES (@patientId, @doctorId, @appointmentDate, @reason)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        command.Parameters.AddWithValue("@doctorId", doctorId);
                        command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
                        command.Parameters.AddWithValue("@reason", reason ?? "");
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Appointment scheduled successfully!");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scheduling appointment: {ex.Message}");
                return false;
            }
        }
        
        public void GetAllAppointments()
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT a.*, p.FirstName as PatientFirstName, p.LastName as PatientLastName,
                                    d.FirstName as DoctorFirstName, d.LastName as DoctorLastName
                                    FROM Appointments a
                                    JOIN Patients p ON a.PatientID = p.PatientID
                                    JOIN Doctors d ON a.DoctorID = d.DoctorID
                                    ORDER BY a.AppointmentDate DESC";
                    
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No appointments found in the database.");
                            return;
                        }

                        Console.WriteLine("\n=== ALL APPOINTMENTS ===");
                        Console.WriteLine("ID | Patient | Doctor | Date | Status");
                        Console.WriteLine("----------------------------------------");
                        
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["AppointmentID"]} | {reader["PatientFirstName"]} {reader["PatientLastName"]} | Dr. {reader["DoctorFirstName"]} {reader["DoctorLastName"]} | {reader["AppointmentDate"]} | {reader["Status"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading appointments: {ex.Message}");
            }
        }
        
        public bool UpdateAppointmentStatus(int appointmentId, string status)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Appointments SET Status = @status WHERE AppointmentID = @appointmentId";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status", ValidateAppointmentStatus(status));
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Appointment {appointmentId} status updated to {status}!");
                        }
                        else
                        {
                            Console.WriteLine("Appointment not found!");
                        }
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
                return false;
            }
        }
        
        private string ValidateAppointmentStatus(string status)
        {
            if (string.IsNullOrEmpty(status)) return "Scheduled";
            
            status = status.ToLower();
            return status switch
            {
                "scheduled" or "s" => "Scheduled",
                "completed" or "c" => "Completed",
                "cancelled" or "cancel" => "Cancelled",
                _ => "Scheduled" // Default if invalid
            };
        }
    }

    // MEDICAL RECORD REPOSITORY
    public class MedicalRecordRepository
    {
        private DatabaseHelper dbHelper;
        public MedicalRecordRepository() => dbHelper = new DatabaseHelper();
        
        public bool AddMedicalRecord(int patientId, int doctorId, int? appointmentId, 
                                   string diagnosis, string prescription, string notes, DateTime recordDate)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO MedicalRecords 
                                    (PatientID, DoctorID, AppointmentID, Diagnosis, Prescription, Notes, RecordDate) 
                                    VALUES (@patientId, @doctorId, @appointmentId, @diagnosis, @prescription, @notes, @recordDate)";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        command.Parameters.AddWithValue("@doctorId", doctorId);
                        command.Parameters.AddWithValue("@appointmentId", appointmentId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@diagnosis", diagnosis ?? "");
                        command.Parameters.AddWithValue("@prescription", prescription ?? "");
                        command.Parameters.AddWithValue("@notes", notes ?? "");
                        command.Parameters.AddWithValue("@recordDate", recordDate.ToString("yyyy-MM-dd"));
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Medical record added successfully!");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding medical record: {ex.Message}");
                return false;
            }
        }
        
        public void GetPatientMedicalRecords(int patientId)
        {
            try
            {
                using (var connection = dbHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT mr.*, d.FirstName as DoctorFirstName, d.LastName as DoctorLastName
                                    FROM MedicalRecords mr
                                    JOIN Doctors d ON mr.DoctorID = d.DoctorID
                                    WHERE mr.PatientID = @patientId
                                    ORDER BY mr.RecordDate DESC";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@patientId", patientId);
                        
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine($"ℹ️  No medical records found for patient {patientId}.");
                                return;
                            }

                            Console.WriteLine($"\n=== MEDICAL RECORDS FOR PATIENT {patientId} ===");
                            
                            while (reader.Read())
                            {
                                Console.WriteLine($"\nRecord Date: {reader["RecordDate"]:yyyy-MM-dd}");
                                Console.WriteLine($"Doctor: Dr. {reader["DoctorFirstName"]} {reader["DoctorLastName"]}");
                                Console.WriteLine($"Diagnosis: {reader["Diagnosis"]}");
                                Console.WriteLine($"Prescription: {reader["Prescription"]}");
                                Console.WriteLine($"Notes: {reader["Notes"]}");
                                if (!reader.IsDBNull(reader.GetOrdinal("AppointmentID")))
                                    Console.WriteLine($"Appointment ID: {reader["AppointmentID"]}");
                                Console.WriteLine("---");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading medical records: {ex.Message}");
            }
        }
    }
}