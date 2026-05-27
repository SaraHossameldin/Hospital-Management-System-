# 🏥 Mock Hospital Management System (HMS)

## 📌 Overview

The **Hospital Management System (HMS)** is a desktop-based application designed to simplify and digitalize the core operations inside a hospital.

The system helps manage:

* Patient registration
* Appointment booking
* Medical records
* Doctor scheduling
* Staff management

The project will be developed using:

* **C# (WinForms)** for the graphical user interface
* **MySQL** for database management

The main objective of this system is to reduce dependency on paper-based processes and manual communication between patients, doctors, and hospital staff.

By centralizing hospital data into one secure platform, the system aims to:

* Improve efficiency
* Reduce human error
* Minimize delays
* Improve accessibility of patient records

---

# 🎯 Target Users

## 👤 Patients

Patients can:

* Register accounts
* Book appointments
* Cancel or reschedule appointments
* View medical history

## 👨‍⚕️ Doctors

Doctors can:

* Manage availability
* Access patient records
* Update diagnoses and treatments
* View appointment schedules

## 👩‍💼 Receptionists & Staff

Staff members can:

* Search patient records
* View appointments
* Access doctor availability
* Manage hospital operations

## 🏢 Hospital Administration

Administrators can:

* Add or remove staff members
* Manage doctor and nurse records
* Monitor system operations

---

# 💡 Motivation

Hospitals handle large amounts of patient and operational data daily. Managing this information manually often causes:

* Data loss
* Miscommunication
* Delays
* Human errors

The Hospital Management System solves these issues by connecting patients, doctors, and staff through one centralized platform.

From a software engineering perspective, this project also applies:

* Modularity
* Layered architecture
* Scrum development
* Database management concepts

This project transforms theoretical concepts into a real-world working system.

---

# 🚀 Core Features

## 1️⃣ User Authentication & Registration

Users can register and log in securely based on their role.

### Features

* Patient registration
* Staff registration using Staff ID
* Secure login system
* Role-based dashboard access

### Implementation

* Users table with:

  * ID
  * Username
  * Password
  * Role
* Password hashing for security
* Automatic dashboard redirection after login

---

## 2️⃣ Patient Appointment Booking System

Patients can search for doctors and book appointments.

### Features

* View available doctors
* Filter doctors by specialty
* Book appointment time slots
* Receive booking confirmation

### Implementation

* Doctor availability scheduling
* Appointment management system
* Dynamic slot updates

---

## 3️⃣ View, Cancel & Reschedule Appointments

Patients can manage all their appointments easily.

### Features

* View upcoming appointments
* Cancel appointments
* Reschedule appointments
* Real-time appointment updates

### Implementation

* Appointment dashboard
* Cancel & reschedule functionality
* Automatic schedule synchronization

---

## 4️⃣ Patient Medical Records

Patients and doctors can access medical records.

### Features

* View diagnoses history
* Access patient medical records
* Update treatments and diagnoses

### Implementation

* Medical records database table
* Patient search functionality
* Record update system

---

## 5️⃣ Doctor Availability Management

Doctors can manage their working hours and availability.

### Features

* Set available working hours
* Modify schedules
* Remove unavailable time slots

### Implementation

* Calendar-based scheduling system
* Dynamic patient booking filtering

---

# 📋 Product Backlog

## 1. Patient Registration

### User Story

As a patient, I want to create an account using a username and password so that I can manage my appointments.

### Acceptance Criteria

* Unique usernames are required.
* Invalid passwords trigger error messages.
* Successful registration displays a confirmation message.

### Functional Requirements

* Username validation
* Password validation
* Account creation

### Non-Functional Requirements

* User-friendly interface
* Fast response time
* Immediate data storage

---

## 2. Staff Registration

### User Story

As a staff member, I want to register using my Staff ID so that I can access system functionalities.

### Acceptance Criteria

* Staff ID must exist in records.
* Invalid IDs display error messages.
* Valid registrations create accounts successfully.

---

## 3. User Login

### User Story

As a system user, I want to log in securely to access my dashboard.

### Acceptance Criteria

* Correct credentials allow login.
* Incorrect credentials display an error.
* Successful login redirects users.

### Non-Functional Requirements

* Password encryption
* Auto logout after inactivity

---

## 4. View Doctors & Specialties

### User Story

As a patient, I want to view available doctors and specialties so that I can choose the most suitable doctor.

### Acceptance Criteria

* Doctors appear based on availability.
* Specialty filtering is supported.
* Unavailable doctors are hidden.

---

## 5. Appointment Booking

### User Story

As a patient, I want to book appointments online to avoid long queues.

### Acceptance Criteria

* Patients can choose available slots.
* Booked slots become unavailable.
* Booking confirmation is displayed.

---

## 6. Appointment Rescheduling & Cancellation

### User Story

As a patient, I want to reschedule or cancel appointments easily.

### Acceptance Criteria

* Appointment updates are reflected immediately.
* Canceled slots become available again.
* Confirmation messages are displayed.

---

## 7. View Appointments

### User Story

As a patient, I want to view all my appointments.

### Acceptance Criteria

* Upcoming appointments are listed.
* Empty appointment lists display a message.

---

## 8. Medical History Access

### User Story

As a patient, I want to view my previous diagnoses.

### Acceptance Criteria

* Medical history is displayed.
* Empty records display a message.

---

## 9. Availability Notifications

### User Story

As a patient, I want to receive notifications when doctor schedules change.

### Acceptance Criteria

* Notifications are sent automatically.
* Unavailable slots disappear immediately.

---

## 🔟 Doctor Availability Management

### User Story

As a doctor, I want to manage my availability.

### Acceptance Criteria

* Doctors can set working hours.
* Patients only see available slots.
* Availability updates sync automatically.

---

## 1️⃣1️⃣ Appointment Cancellation Alerts

### User Story

As a doctor, I want to receive cancellation alerts.

### Acceptance Criteria

* Doctors receive alerts after cancellations.
* Canceled slots become available again.

---

## 1️⃣2️⃣ Staff Management

### User Story

As an administrator, I want to manage hospital staff records.

### Acceptance Criteria

* Staff can be added or removed.
* Updates appear instantly.
* Access is restricted to administrators.

---

## 1️⃣3️⃣ Access Patient Records

### User Story

As a doctor, I want to access patient records for better diagnosis.

### Acceptance Criteria

* Doctors can search patient history.
* Empty records display appropriate messages.

---

## 1️⃣4️⃣ Update Medical Records

### User Story

As a doctor, I want to update patient diagnoses and treatments.

### Acceptance Criteria

* Updates are saved instantly.
* Patients can view updated history.

---

## 1️⃣5️⃣ Doctor Appointment Dashboard

### User Story

As a doctor, I want to view all scheduled appointments.

### Acceptance Criteria

* Appointments are listed clearly.
* Empty schedules display messages.
* Rescheduled appointments update automatically.

---

## 1️⃣6️⃣ Patient Search System

### User Story

As a receptionist, I want to search for patients by name.

### Acceptance Criteria

* Matching patient records are displayed.
* No results display a message.
* Appointment details are accessible.

---

## 1️⃣7️⃣ View Patient Information

### User Story

As a receptionist, I want to view patient contact information.

### Acceptance Criteria

* Patient details are displayed.
* Phone numbers and emails are accessible.

---

## 1️⃣8️⃣ Doctor Availability Tracking

### User Story

As a receptionist, I want to monitor doctor availability.

### Acceptance Criteria

* Doctor schedules are visible.
* Updated hours appear immediately.

---

## 1️⃣9️⃣ Upcoming Appointment Management

### User Story

As a receptionist, I want to view all upcoming appointments.

### Acceptance Criteria

* Upcoming bookings are listed.
* Canceled appointments disappear.
* New bookings appear automatically.

---

## 2️⃣0️⃣ Nurse Availability Management

### User Story

As a nurse, I want to manage my working hours.

### Acceptance Criteria

* Nurses can update schedules.
* Saved updates appear immediately.

---

# 🏗️ High-Level System Architecture

The system follows a layered architecture consisting of:

* Presentation Layer (WinForms UI)
* Business Logic Layer
* Data Access Layer
* MySQL Database Layer

This structure improves:

* Maintainability
* Scalability
* Modularity

---

# ⚠️ Risks Identified

## 🔧 Technical Risks

### Database Failure

Improper backups may lead to data loss or corruption.

### Weak Encryption

Weak security mechanisms may expose sensitive patient data.

### Integration Issues

Poor integration between modules may cause inconsistencies.

### Performance Issues

Large amounts of hospital data may reduce system performance.

---

## ⚙️ Operational Risks

### Resistance to Change

Hospital staff may resist adapting to new technologies.

### Data Entry Errors

Incorrect manual entries may affect medical records accuracy.

---

## 📅 Managerial Risks

### Feature Creep

Adding unnecessary features may affect project scope.

### Time Management Issues

Miscommunication between team members may delay progress.

### Dependency Risks

Some modules depend heavily on others, slowing development.

---

# 🛠️ Technologies Used

* C#
* WinForms
* MySQL
* Scrum Methodology
* Object-Oriented Programming (OOP)

---

# 📖 Future Improvements

Possible future enhancements include:

* Online payment integration
* Mobile application support
* AI-assisted diagnosis suggestions
* SMS & email notifications
* Cloud database hosting

---

# 👥 Team Information

**Course:** CSCE3701 – Software Engineering

**Milestone:** Milestone 1 Report

**Group Number:** 01

**Module Instructor:** Dr. Yasmine Afify

**Teaching Assistant:** Asmaa Hasan

---

# ✅ Conclusion

The Mock Hospital Management System aims to modernize hospital workflows through a centralized digital platform.

By combining secure authentication, appointment scheduling, medical record management, and staff coordination, the system improves both hospital efficiency and patient experience.

The project also serves as a practical application of software engineering principles, transforming theoretical knowledge into a functional real-world solution.
