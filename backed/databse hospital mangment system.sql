create database Hospital_Mangemt_system;

use Hospital_Mangemt_system;

-- patients
CREATE TABLE Patients (
    PatientID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender ENUM('Male', 'Female', 'Other'),
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100),
    Address TEXT,
    BloodGroup VARCHAR(5),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Doctors
CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Specialization VARCHAR(100),
    PhoneNumber VARCHAR(15),
    Email VARCHAR(100),
    LicenseNumber VARCHAR(50) UNIQUE,
    ConsultationFee DECIMAL(10,2),
    Status ENUM('Active', 'Inactive', 'Left') DEFAULT 'Active',
    LeftDate DATE NULL,  -- Track when they left
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Appointments stays the same with RESTRICT
CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Status ENUM('Scheduled', 'Completed', 'Cancelled') DEFAULT 'Scheduled',
    Reason TEXT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID) 
        ON UPDATE CASCADE 
        ON DELETE RESTRICT,
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID) 
        ON UPDATE CASCADE 
        ON DELETE RESTRICT  -- Keep RESTRICT!
);

-- User 
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Role ENUM('Admin', 'Doctor', 'Receptionist') NOT NULL,
    Email VARCHAR(100),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Appointment
CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Status ENUM('Scheduled', 'Completed', 'Cancelled') DEFAULT 'Scheduled',
    Reason TEXT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);

-- MedicalRecords
CREATE TABLE MedicalRecords (
    RecordID INT PRIMARY KEY AUTO_INCREMENT,
    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,
    AppointmentID INT NULL,  -- FK: Links to appointment (if there was one)
    Diagnosis TEXT NOT NULL,
    Prescription TEXT,
    Notes TEXT,
    RecordDate DATE NOT NULL,  -- Regular field: When THIS record's event happened
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- When entered into system
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID),
    FOREIGN KEY (AppointmentID) REFERENCES Appointments(AppointmentID)
        ON DELETE SET NULL
);


