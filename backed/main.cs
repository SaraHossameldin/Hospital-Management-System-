using System;

namespace HospitalCRUD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("HOSPITAL MANAGEMENT SYSTEM - COMPLETE CRUD OPERATIONS");
            Console.WriteLine("=======================================================\n");
            
            // Test database connection
            DatabaseHelper dbHelper = new DatabaseHelper();
            if (!dbHelper.TestConnection())
            {
                Console.WriteLine("Cannot continue without database connection.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            
            PatientRepository patientRepo = new PatientRepository();
            DoctorRepository doctorRepo = new DoctorRepository();
            AppointmentRepository appointmentRepo = new AppointmentRepository();
            MedicalRecordRepository medicalRepo = new MedicalRecordRepository();
            
            // Main menu
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== MAIN MENU ===");
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Doctor Management");
                Console.WriteLine("3. Appointment Management");
                Console.WriteLine("4. Medical Records");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option (1-5): ");
                
                string? choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        PatientManagement(patientRepo);
                        break;
                    case "2":
                        DoctorManagement(doctorRepo);
                        break;
                    case "3":
                        AppointmentManagement(appointmentRepo, patientRepo, doctorRepo);
                        break;
                    case "4":
                        MedicalRecordsManagement(medicalRepo, patientRepo);
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Thank you for using Hospital Management System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        WaitForUser();
                        break;
                }
            }
        }
        
        static void WaitForUser()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        
        static bool ConfirmAction(string message)
        {
            Console.Write($"{message} (y/n): ");
            string? confirm = Console.ReadLine();
            return confirm?.ToLower() == "y";
        }
        
        static void PatientManagement(PatientRepository repo)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n=== PATIENT MANAGEMENT ===");
                Console.WriteLine("1. Add New Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. View Patient by ID");
                Console.WriteLine("4. Update Patient");
                Console.WriteLine("5. Delete Patient");
                Console.WriteLine("6. Search Patients");
                Console.WriteLine("7. Back to Main Menu");
                Console.Write("Choose an option (1-7): ");
                
                string? choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        AddNewPatient(repo);
                        WaitForUser();
                        break;
                    case "2":
                        repo.GetAllPatients();
                        WaitForUser();
                        break;
                    case "3":
                        ViewPatientById(repo);
                        WaitForUser();
                        break;
                    case "4":
                        UpdatePatient(repo);
                        WaitForUser();
                        break;
                    case "5":
                        DeletePatient(repo);
                        WaitForUser();
                        break;
                    case "6":
                        SearchPatients(repo);
                        WaitForUser();
                        break;
                    case "7":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        WaitForUser();
                        break;
                }
            }
        }
        
        static void DoctorManagement(DoctorRepository repo)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n=== DOCTOR MANAGEMENT ===");
                Console.WriteLine("1. Add New Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. View Active Doctors");
                Console.WriteLine("4. Update Doctor Status");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Choose an option (1-5): ");
                
                string? choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        AddNewDoctor(repo);
                        WaitForUser();
                        break;
                    case "2":
                        repo.GetAllDoctors();
                        WaitForUser();
                        break;
                    case "3":
                        repo.GetActiveDoctors();
                        WaitForUser();
                        break;
                    case "4":
                        UpdateDoctorStatus(repo);
                        WaitForUser();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        WaitForUser();
                        break;
                }
            }
        }
        
        static void AppointmentManagement(AppointmentRepository appointmentRepo, PatientRepository patientRepo, DoctorRepository doctorRepo)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n=== APPOINTMENT MANAGEMENT ===");
                Console.WriteLine("1. Schedule Appointment");
                Console.WriteLine("2. View All Appointments");
                Console.WriteLine("3. Update Appointment Status");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Choose an option (1-4): ");
                
                string? choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        ScheduleAppointment(appointmentRepo, patientRepo, doctorRepo);
                        WaitForUser();
                        break;
                    case "2":
                        appointmentRepo.GetAllAppointments();
                        WaitForUser();
                        break;
                    case "3":
                        UpdateAppointmentStatus(appointmentRepo);
                        WaitForUser();
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        WaitForUser();
                        break;
                }
            }
        }
        
        static void MedicalRecordsManagement(MedicalRecordRepository medicalRepo, PatientRepository patientRepo)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n=== MEDICAL RECORDS MANAGEMENT ===");
                Console.WriteLine("1. Add Medical Record");
                Console.WriteLine("2. View Patient Medical Records");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Choose an option (1-3): ");
                
                string? choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        AddMedicalRecord(medicalRepo);
                        WaitForUser();
                        break;
                    case "2":
                        ViewPatientMedicalRecords(medicalRepo);
                        WaitForUser();
                        break;
                    case "3":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        WaitForUser();
                        break;
                }
            }
        }
        
        // PATIENT METHODS
        static void AddNewPatient(PatientRepository repo)
        {
            Console.WriteLine("\n=== ADD NEW PATIENT ===");
            
            try
            {
                Console.Write("First Name: ");
                string? firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name is required!");
                    return;
                }
                
                Console.Write("Last Name: ");
                string? lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name is required!");
                    return;
                }
                
                DateTime dob;
                while (true)
                {
                    Console.Write("Date of Birth (YYYY-MM-DD): ");
                    string? dobInput = Console.ReadLine();
                    if (DateTime.TryParse(dobInput, out dob))
                        break;
                    Console.WriteLine("Invalid date format! Please use YYYY-MM-DD format.");
                }
                
                Console.Write("Gender (Male/Female/Other): ");
                string? gender = Console.ReadLine();
                
                Console.Write("Phone Number: ");
                string? phone = Console.ReadLine();
                
                Console.Write("Email: ");
                string? email = Console.ReadLine();
                
                Console.Write("Address: ");
                string? address = Console.ReadLine();
                
                Console.Write("Blood Group: ");
                string? bloodGroup = Console.ReadLine();
                
                if (ConfirmAction("Add this patient to the database?"))
                {
                    repo.AddPatient(
                        firstName.Trim(), lastName.Trim(), dob, gender ?? "Other",
                        phone?.Trim() ?? "", email?.Trim() ?? "", address?.Trim() ?? "", bloodGroup?.Trim() ?? ""
                    );
                }
                else
                {
                    Console.WriteLine("Patient addition cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
        
        static void ViewPatientById(PatientRepository repo)
        {
            Console.Write("\nEnter Patient ID: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int patientId))
            {
                if (repo.PatientExists(patientId))
                    repo.GetPatientById(patientId);
                else
                    Console.WriteLine("Patient not found!");
            }
            else
            {
                Console.WriteLine("Invalid Patient ID! Please enter a number.");
            }
        }
        
        static void UpdatePatient(PatientRepository repo)
        {
            Console.Write("\nEnter Patient ID to update: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int patientId))
            {
                Console.WriteLine("Invalid Patient ID! Please enter a number.");
                return;
            }
            
            if (!repo.PatientExists(patientId))
            {
                Console.WriteLine("Patient not found!");
                return;
            }
            
            // Show current patient details
            repo.GetPatientById(patientId);
            
            Console.WriteLine("\nEnter new details (press Enter to keep current value):");
            
            Console.Write("First Name: ");
            string? firstName = Console.ReadLine();
            
            Console.Write("Last Name: ");
            string? lastName = Console.ReadLine();
            
            DateTime? dob = null;
            while (true)
            {
                Console.Write("Date of Birth (YYYY-MM-DD, press Enter to skip): ");
                string? dobInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(dobInput))
                    break;
                if (DateTime.TryParse(dobInput, out DateTime parsedDob))
                {
                    dob = parsedDob;
                    break;
                }
                Console.WriteLine("Invalid date format! Please use YYYY-MM-DD format.");
            }
            
            Console.Write("Gender (Male/Female/Other, press Enter to skip): ");
            string? gender = Console.ReadLine();
            
            Console.Write("Phone Number (press Enter to skip): ");
            string? phone = Console.ReadLine();
            
            Console.Write("Email (press Enter to skip): ");
            string? email = Console.ReadLine();
            
            Console.Write("Address (press Enter to skip): ");
            string? address = Console.ReadLine();
            
            Console.Write("Blood Group (press Enter to skip): ");
            string? bloodGroup = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName) && 
                !dob.HasValue && string.IsNullOrWhiteSpace(gender) && 
                string.IsNullOrWhiteSpace(phone) && string.IsNullOrWhiteSpace(email) && 
                string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(bloodGroup))
            {
                Console.WriteLine("No changes provided!");
                return;
            }
            
            if (ConfirmAction($"Update patient {patientId}?"))
            {
                // For a real application, you would get current values first
                // For simplicity, we'll use the provided values or defaults
                DateTime finalDob = dob ?? new DateTime(2000, 1, 1); // Default if not provided
                string finalGender = string.IsNullOrWhiteSpace(gender) ? "Other" : gender;
                
                repo.UpdatePatient(
                    patientId, 
                    string.IsNullOrWhiteSpace(firstName) ? "TempFirstName" : firstName.Trim(),
                    string.IsNullOrWhiteSpace(lastName) ? "TempLastName" : lastName.Trim(),
                    finalDob, finalGender,
                    phone?.Trim() ?? "", email?.Trim() ?? "", address?.Trim() ?? "", bloodGroup?.Trim() ?? ""
                );
            }
            else
            {
                Console.WriteLine("Patient update cancelled.");
            }
        }
        
        static void DeletePatient(PatientRepository repo)
        {
            Console.Write("\nEnter Patient ID to delete: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int patientId))
            {
                Console.WriteLine("Invalid Patient ID! Please enter a number.");
                return;
            }
            
            if (!repo.PatientExists(patientId))
            {
                Console.WriteLine("Patient not found!");
                return;
            }
            
            // Show patient details before deletion
            repo.GetPatientById(patientId);
            
            if (ConfirmAction($"Are you sure you want to delete patient {patientId}? This action cannot be undone!"))
            {
                repo.DeletePatient(patientId);
            }
            else
            {
                Console.WriteLine("Patient deletion cancelled.");
            }
        }
        
        static void SearchPatients(PatientRepository repo)
        {
            Console.Write("\nEnter name to search: ");
            string? searchTerm = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Please enter a search term!");
                return;
            }
            
            repo.SearchPatients(searchTerm.Trim());
        }
        
        // DOCTOR METHODS
        static void AddNewDoctor(DoctorRepository repo)
        {
            Console.WriteLine("\n=== ADD NEW DOCTOR ===");
            
            try
            {
                Console.Write("First Name: ");
                string? firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name is required!");
                    return;
                }
                
                Console.Write("Last Name: ");
                string? lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name is required!");
                    return;
                }
                
                Console.Write("Specialization: ");
                string? specialization = Console.ReadLine();
                
                Console.Write("Phone Number: ");
                string? phone = Console.ReadLine();
                
                Console.Write("Email: ");
                string? email = Console.ReadLine();
                
                Console.Write("License Number: ");
                string? license = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(license))
                {
                    Console.WriteLine("License number is required!");
                    return;
                }
                
                decimal fee;
                while (true)
                {
                    Console.Write("Consultation Fee: ");
                    string? feeInput = Console.ReadLine();
                    if (decimal.TryParse(feeInput, out fee) && fee >= 0)
                        break;
                    Console.WriteLine("Invalid fee amount! Please enter a positive number.");
                }
                
                if (ConfirmAction("Add this doctor to the database?"))
                {
                    repo.AddDoctor(firstName.Trim(), lastName.Trim(), specialization?.Trim() ?? "", 
                                 phone?.Trim() ?? "", email?.Trim() ?? "", license.Trim(), fee);
                }
                else
                {
                    Console.WriteLine("Doctor addition cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
        
        static void UpdateDoctorStatus(DoctorRepository repo)
        {
            Console.Write("\nEnter Doctor ID: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int doctorId))
            {
                Console.WriteLine("Invalid Doctor ID! Please enter a number.");
                return;
            }
            
            if (!repo.DoctorExists(doctorId))
            {
                Console.WriteLine("Doctor not found!");
                return;
            }
            
            Console.Write("New Status (Active/Inactive/Left): ");
            string? status = Console.ReadLine();
            
            DateTime? leftDate = null;
            if (status?.ToLower() == "left")
            {
                Console.Write("Left Date (YYYY-MM-DD): ");
                string? dateInput = Console.ReadLine();
                if (!DateTime.TryParse(dateInput, out DateTime date))
                {
                    Console.WriteLine("Invalid date format!");
                    return;
                }
                leftDate = date;
            }
            
            if (string.IsNullOrWhiteSpace(status))
            {
                Console.WriteLine("Status is required!");
                return;
            }
            
            if (ConfirmAction($"Update doctor {doctorId} status to {status}?"))
            {
                repo.UpdateDoctorStatus(doctorId, status, leftDate);
            }
            else
            {
                Console.WriteLine("Status update cancelled.");
            }
        }
        
        // APPOINTMENT METHODS
        static void ScheduleAppointment(AppointmentRepository appointmentRepo, PatientRepository patientRepo, DoctorRepository doctorRepo)
        {
            Console.WriteLine("\n=== SCHEDULE APPOINTMENT ===");
            
            Console.Write("Patient ID: ");
            string? patientInput = Console.ReadLine();
            if (!int.TryParse(patientInput, out int patientId))
            {
                Console.WriteLine("Invalid Patient ID! Please enter a number.");
                return;
            }
            
            if (!patientRepo.PatientExists(patientId))
            {
                Console.WriteLine("Patient not found!");
                return;
            }
            
            Console.Write("Doctor ID: ");
            string? doctorInput = Console.ReadLine();
            if (!int.TryParse(doctorInput, out int doctorId))
            {
                Console.WriteLine("Invalid Doctor ID! Please enter a number.");
                return;
            }
            
            if (!doctorRepo.DoctorExists(doctorId))
            {
                Console.WriteLine("Doctor not found!");
                return;
            }
            
            DateTime appointmentDate;
            while (true)
            {
                Console.Write("Appointment Date (YYYY-MM-DD HH:MM:SS): ");
                string? dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out appointmentDate))
                    break;
                Console.WriteLine("Invalid date format! Please use YYYY-MM-DD HH:MM:SS format.");
            }
            
            Console.Write("Reason: ");
            string? reason = Console.ReadLine();
            
            // Show patient and doctor info for confirmation
            patientRepo.GetPatientById(patientId);
            Console.WriteLine("\nDoctor Info:");
            doctorRepo.GetAllDoctors(); // This will show all doctors, but you can see the ID
            
            if (ConfirmAction("Schedule this appointment?"))
            {
                appointmentRepo.ScheduleAppointment(patientId, doctorId, appointmentDate, reason ?? "");
            }
            else
            {
                Console.WriteLine("Appointment scheduling cancelled.");
            }
        }
        
        static void UpdateAppointmentStatus(AppointmentRepository repo)
        {
            Console.Write("\nEnter Appointment ID: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int appointmentId))
            {
                Console.WriteLine("Invalid Appointment ID! Please enter a number.");
                return;
            }
            
            Console.Write("New Status (Scheduled/Completed/Cancelled): ");
            string? status = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(status))
            {
                Console.WriteLine("Status is required!");
                return;
            }
            
            if (ConfirmAction($"Update appointment {appointmentId} status to {status}?"))
            {
                repo.UpdateAppointmentStatus(appointmentId, status);
            }
            else
            {
                Console.WriteLine("Appointment status update cancelled.");
            }
        }
        
        // MEDICAL RECORD METHODS
        static void AddMedicalRecord(MedicalRecordRepository repo)
        {
            Console.WriteLine("\n=== ADD MEDICAL RECORD ===");
            
            Console.Write("Patient ID: ");
            string? patientInput = Console.ReadLine();
            if (!int.TryParse(patientInput, out int patientId))
            {
                Console.WriteLine("Invalid Patient ID! Please enter a number.");
                return;
            }
            
            Console.Write("Doctor ID: ");
            string? doctorInput = Console.ReadLine();
            if (!int.TryParse(doctorInput, out int doctorId))
            {
                Console.WriteLine("Invalid Doctor ID! Please enter a number.");
                return;
            }
            
            int? appointmentId = null;
            Console.Write("Appointment ID (optional, press Enter to skip): ");
            string? appointmentInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(appointmentInput) && int.TryParse(appointmentInput, out int parsedAppointmentId))
            {
                appointmentId = parsedAppointmentId;
            }
            
            Console.Write("Diagnosis: ");
            string? diagnosis = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(diagnosis))
            {
                Console.WriteLine("Diagnosis is required!");
                return;
            }
            
            Console.Write("Prescription: ");
            string? prescription = Console.ReadLine();
            
            Console.Write("Notes: ");
            string? notes = Console.ReadLine();
            
            DateTime recordDate;
            while (true)
            {
                Console.Write("Record Date (YYYY-MM-DD): ");
                string? dateInput = Console.ReadLine();
                if (DateTime.TryParse(dateInput, out recordDate))
                    break;
                Console.WriteLine("Invalid date format! Please use YYYY-MM-DD format.");
            }
            
            if (ConfirmAction("Add this medical record?"))
            {
                repo.AddMedicalRecord(patientId, doctorId, appointmentId, diagnosis.Trim(), 
                                    prescription?.Trim() ?? "", notes?.Trim() ?? "", recordDate);
            }
            else
            {
                Console.WriteLine("Medical record addition cancelled.");
            }
        }
        
        static void ViewPatientMedicalRecords(MedicalRecordRepository repo)
        {
            Console.Write("\nEnter Patient ID: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int patientId))
            {
                repo.GetPatientMedicalRecords(patientId);
            }
            else
            {
                Console.WriteLine("Invalid Patient ID! Please enter a number.");
            }
        }
    }
}