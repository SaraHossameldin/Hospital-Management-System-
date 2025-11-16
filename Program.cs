using System;
using System.Windows.Forms;
using HMS.Registration;         
using HMS.Admin_Functionalities; 
using HMS.Login_Story;          

namespace HMS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Shared repositories
            var patientRepo = new MockPatientRepository();
            var staffRepo = new MockStaffRepository();

            // Seed staff
            staffRepo.Add(new Staff
            {
                StaffID = 1,
                FirstName = "Super",
                LastName = "Admin",
                Username = "admin",
                PasswordHash = AuthService.HashPassword("Admin@123"),
                Email = "admin@example.com",
                Role = Role.Admin,
                Status = StaffStatus.Active
            });

            staffRepo.Add(new Staff
            {
                StaffID = 2,
                FirstName = "John",
                LastName = "Doe",
                Username = "",
                PasswordHash = "",
                Email = "johndoe@example.com",
                Department = "Cardiology",
                Role = Role.Doctor,
                Status = StaffStatus.Inactive
            });

            staffRepo.Add(new Staff
            {
                StaffID = 3,
                FirstName = "Alice",
                LastName = "Smith",
                Username = "alicesmith",
                PasswordHash = AuthService.HashPassword("Alice@123"),
                Email = "alicesmith@example.com",
                Department = "Neurology",
                Role = Role.Doctor,
                Status = StaffStatus.Active
            });

            staffRepo.ResetNextId(); // Next new ID will be 4

            // Seed patients
            patientRepo.Add(new Patient
            {
                PatientID = 1,
                FirstName = "Sara",
                LastName = "Hossam",
                Username = "sarah",
                PasswordHash = AuthService.HashPassword("Patient@123"),
                DateOfBirth = new DateTime(2000, 1, 1),
                Gender = "Female",
                Email = "sara@example.com"
            });

            // Shared services
            var staffService = new StaffService(staffRepo);
            var authService = new AuthService(patientRepo, staffService);
            var patientService = new PatientService(patientRepo);

            // Single instance of LoginForm
            var loginForm = new LoginForm(authService, patientService, staffService);
            Application.Run(loginForm);
        }
    }
}
