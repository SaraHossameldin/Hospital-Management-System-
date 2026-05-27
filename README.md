# Mock Hospotal Management System Implementation
Overview of the SW
Our proposed project is a Hospital Management System (HMS) that aims to simplify and
digitalize the main operations inside a hospital. The system will help manage patient
registration, appointment booking, medical records, and doctor scheduling in one place. It
will be developed as a desktop application using C# (WinForms) for the interface and MySQL
for the database.
The main goal is to move away from paper files and manual communication between
doctors, patients, and staff. In many hospitals, information is scattered or handled by phone
calls and handwritten notes, which often leads to confusion and delays. Our system will
make this process faster, more organized, and less error-prone by keeping all data
centralized and easy to access.
Target Users
Patients: register, book or cancel appointments, and view their medical history.
Doctors: check their schedules, access patient history, and update diagnoses.
Staff: manage departments, assign beds, and record lab services.
Hospital Management: monitor performance and ensure smooth daily operations.
Motivation
Hospitals deal with large volumes of data every day, and handling it manually often causes
mistakes, data loss, and wasted time. The HMS solves this by connecting everyone; patients,
doctors, and staff, through one secure platform. It reduces the need for repeated data entry
and helps doctors make faster and better informed decisions.
From a software-engineering point of view, this project also lets us apply what we learned
about modularity, layered architecture, and Scrum development, turning theoretical
concepts into a working real life system.
The product backlog
1. As a patient, I want to create an account using a username and password, so that I can
manage my appointments.
Acceptance criteria:
● Given a new patient is on the registration page, when he/she enters a unique
username and a valid password, then his/her account should be successfully created.
● Given a new patient enters a username that is already used, when the patient
submits the form, then the system should display an error message.
2
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
● Given a new patient enters a password that is not valid, when the patient submits
the form, then the system should display an error message.
Functional Requirements:
● The system shall allow the user to enter the username and password to create a new
account.
● The system shall verify the uniqueness of the username to ensure that it is not
already used.
● The system shall validate that the password is valid based on certain security criteria.
Non-Functional Requirements:
● The registration interface shall be easy to understand and use, providing clear labels
for all fields.
● The system shall store new accounts immediately after submission is done.
● The system shall display a confirmation message only 1 second after the account is
successfully created.
2. As a staff member, I want to register for an account using my ID, so that I can have
access to perform my functionalities on the system.
Acceptance Criteria:
● Given a staff member is on the registration page, when he/she enters a valid staff ID,
then the system should verify that this ID exists in the staff records before
registration is done.
● Given a staff member enters an ID that is not valid, when the staff member attempts
to register, then the system should show an error message.
● Given the Staff ID is valid, when the staff member completes the registration, then
his/her account should be created.
3. As a system user (patient or staff member), I want to login using my username and
password, so that I can access my dashboard.
Acceptance Criteria:
● Given the user registered successfully, when the user enters his/her username and
password in the login page, then he/she should be logged in and redirected to
his/her dashboard.
● Given the user enters an incorrect username or password, when the user tries to
submit the log in form, then an error message should appear.
● Given the user enters correct username and password, when the user submits the
login form, then a success message is displayed
3
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
Functional Requirements:
● The system shall allow registered users to log in by entering a username and
password in the login form.
● The system shall redirect the user to his/her dashboard if the user logs in using a
valid username and password.
● The system shall display an error message if the user enters an incorrect username or
password.
Non-Functional Requirements:
● The system shall store all passwords in encrypted form to protect user data.
● The system shall automatically log out the user after 20 minutes of inactivity.
4. As a patient, I want to see the available doctors and their specialty, so that I can choose
the most suitable one.
Acceptance Criteria:
● Given a patient successfully logged in, when he/she goes to the “Booking” section,
then the system should display a list of available doctors and their specialty.
● Given a doctor is unavailable, when the patient opens the list of available doctors,
then he/she should not appear in the list.
● Given the patient is at the “Booking” section, when he/she filters by specialty, then
the list should display only the doctors with that specialty.
5. As a patient, I want to book an appointment with a doctor, so that I can avoid having to
wait in long queues.
Acceptance Criteria:
● Given a patient selects a doctor, when he/she chooses a suitable time slot, then the
appointment should be booked successfully.
● Given a timeslot is already taken with a specific doctor, when the patient views the
available slots for that doctor, then the system should not display it in the available
slots.
● Given a patient selects a time slot, when the patient clicks on it, then the patient
should receive a booking confirmation message.
4
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
6. As a patient, I want to be able to reschedule my appointments so that I can adjust my
plans easily.
Acceptance Criteria:
● Given a patient has booked an appointment, when he/she selects a new time slot,
then the system should update the appointment details.
● Given a patient has booked an appointment, when he/she cancels it, then a
confirmation message should be displayed.
● Given a patient has booked an appointment, when he/she cancels it, then it should
appear to other patients as an available slot.
7. As a patient, I want to see a list of my appointments, so that I can cancel them if
needed.
Acceptance Criteria:
● Given a patient is logged in, when he/she opens “My Appointments”, then the
system should show all his/her appointments.
● Given a patient has no appointments, when they open “My Appointments”, then a
“No appointments found” message should appear.
8. As a patient, I want to view my previous diagnoses, so that I can see my medical history.
Acceptance Criteria:
● Given a patient is logged in, when he/she opens “Medical History”, then the system
should list all previous diagnoses.
● Given a patient has no previous diagnoses, when he/she opens “Medical History”,
then a “No Records Available” message should appear.
9. As a patient, I want to be updated when a doctor changes his/her availability, so that I
can avoid booking appointments at unsuitable times.
Acceptance Criteria:
● Given a doctor updates his/her schedule, when a patient’s appointment is affected,
then the system should send a notification to the patient.
● Given a doctor becomes unavailable, when a patient checks the availability of this
doctor, then the doctor’s new unavailable slot does not appear.
10. As a doctor, I want to set my availability, so that patients can only book appointments
with me when I am available.
Acceptance Criteria:
5
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
● Given a doctor is logged into his/her account, when he/she accesses the
“Availability” page, then he/she should be able to set his/her availability.
● Given a doctor removes availability, when a patient tries to book that time, then the
slot should no longer appear.
Functional Requirements:
● The system shall allow the doctor to update his/her working hours by selecting
available times from a calendar interface by selecting the date and exact time.
● The system shall also update the doctor’s working hours in the “Booking” section
used by the patients.
Non-Functional Requirements:
● The system shall reflect the changes in the doctor’s availability on the patient
booking section only after 1 second of saving these changes.
● The Availability page shall be easy to understand and use.
11. As a doctor, I want to receive alerts when a patient cancels an appointment, so that I can
rearrange my schedule.
Acceptance Criteria:
● Given a patient cancels an appointment, when the change is saved, then the doctor
should receive an alert.
● Given a cancellation occurs, when another patient checks the doctor’s availability ,
then the canceled slot should appear as available again.
12. As a hospital administrator, I want to add or remove doctors and nurses from the
system, so that staff records remain up to date.
Acceptance Criteria:
● Given the admin is logged in, when he/she adds a staff member, then, their record
should appear in the staff list.
● Given a staff member is removed, when the admin confirms deletion, then the staff
member does not appear on the list anymore.
● Given a staff update occurs, when the admin saves changes, then the new
information should be reflected in the staff list.
Functional Requirements:
● The system shall allow the administrator to add new doctors by entering name, role,
department, email, and ID.
● The system shall allow the administrator to remove doctors or nurses from the
database when he/she no longer works at the hospital.
6
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
● The system shall allow the administrator to update or change the doctor’s or nurse’s
records.
Non-Functional Requirements:
● The system shall reflect staff list updates after 1 second of saving.
● Only administrators shall have access to the “Staff Management” feature.
13. As a doctor, I want to access the patients’ medical records, so that he/she can provide
better diagnoses.
Acceptance Criteria:
● Given a doctor selects a patient, when he/she opens the record, then he/she can see
the patient’s medical history.
● Given a patient has no history, when the doctor opens the record, then the system
should display “No previous data.”
14. As a doctor, I want to update the patients’ records, so that the system stores up-to-date
information.
Acceptance Criteria:
● Given a doctor finishes an appointment, when he/she enters new treatment or
diagnosis, then the system should save the update.
● Given a record is updated, when the patient views his/her history, then the new
entry should appear.
15. As a doctor, I want to view all my scheduled appointments, so that I can prepare for
each appointment.
Acceptance Criteria:
● Given a doctor logs in, when he/she opens “My Appointments” , then all
appointments should be listed.
● Given there are no appointments, when the doctor opens the page, then the system
should display “No appointments scheduled.”
● Given a patient reschedules, when the doctor refreshes the dashboard, then the list
should automatically update.
16. As a receptionist, I want to search for a patient by name, so that I can view all his/her
upcoming appointments.
Acceptance Criteria:
7
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
● Given the receptionist is logged in, when he/she types a patient’s name, then the
record of the patient with a matching name should appear.
● Given no match is found, when the receptionist searches, then the system should
display “No results found.”
● Given a result is shown, when the receptionist clicks it, then the patient’s details and
appointments should appear.
Functional Requirements:
● The system shall allow the receptionist to enter a patient’s name into a search field
to look for that patient’s record.
● The system shall display all matching patient records including name and contact
details.
● The system shall display a “No results found” message if no patient name matches
the search name.
Non-Functional Requirements:
● The search interface shall be clear and have easily understood input labels.
● Search results shall be displayed after 1 second of submitting the query.
17. As a receptionist, I want to view all the patients’ personal information, so that I can
contact him/her in case of changes.
Acceptance Criteria
● Given the receptionist is logged in, when he/she opens the patient list, then all
patients’ contact details should be displayed.
● Given contact details exist, when the receptionist selects a patient, then the system
should display his/her phone number and email.
18. As a receptionist, I want to assess the doctors’ availability, so that I can be aware of any
changes in their working hours.
Acceptance Criteria:
● Given the receptionist is logged in, when he/she accesses the doctor availability
page, then a list of each doctor’s available slots should appear.
● Given a doctor updates his/her hours, when the receptionist refreshes, then the new
hours should be visible.
19. As a receptionist, I want to view all upcoming appointments, so that I can organize the
daily schedule.
Acceptance Criteria:
8
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
● Given the receptionist is logged in, when he/she opens the”Appointments” section,
then all upcoming bookings should be shown with their dates, times, and doctors.
● Given an appointment is canceled, when the page refreshes, then the appointment
should no longer appear.
● Given a new appointment is booked, when the receptionist checks the list, then it
should appear on the list.
20. As a nurse, I want to update my working hours and availability, so that the hospital can
schedule shifts efficiently.
Acceptance Criteria:
● Given a nurse logs into the system, when he/she opens the "Availability" page, then
he/she should be able to set his/her working hours.
● Given the nurse updates his/her working hours, when he/she clicks “Save”, then the
system should reflect the new times.
WBS diagram
High-level architecture of the system
9
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
Use Case Diagram
Risks Identified
The risks that our team may come across during the development and deployment of this
management system can be categorized into different risks. They involve both technical and
non-technical risks that could affect the project’s timeline and quality.
1. Technical Risks:
- Database failure: Here, during the development stage, we can have data that
isn’t backed up properly so patient information could be lost. As all
information will be stored in a database, there is always a risk of corruption
occurring.
- Weak encryption: A lack of encryption or weak authentication could result in
unauthorized access to patient data, which would violate many laws and
cause major ethical dilemmas.
- Integration issues between modules: Here the system will have multiple
interconnected modules depending on the features included in this system,
and if modules are not integrated correctly, data mistakes and inconsistencies
could occur.
- Performance Issues: As the hospital grows, along with its personnel we can
expect that operations like searching may become slow.
10
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
2. Operational Risks:
- Resistance: Adapting to new technologies and systems will always prove to be
a risk that some developers will be willing to take to ensure a greater
outcome in the long run.
- Data entry mistakes: Incorrect entries by doctors or nurses can lead to
inaccuracies in the medical records, so format checks are an important factor.
3. Managerial Risks:
- Feature Creep: As the management system grows and the project progresses,
we as a team can mistakenly add features that were not accounted for in the
initial scope, or that may have been already implemented.
- Time management & Coordination: Since this project involves multiple team
members miscommunication can lead to delays.
- Dependencies: Some modules prove to be dependent on others, therefore
progress may slow down or stop occasionally leading to more delays.
Core Features
1. User Authentication/Login & Registration
This feature lets people create an account and sign in as a patient or a doctor. After signing
in, each person is taken to the right screen for their role. This keeps accesses organized.
Implementation:
- Create a simple users table with fields: ID, username, password, role.
- Use hashed passwords
- Redirect users to their dashboard after login.
2. Patient Appointment Booking System
Patients can look up doctors by specialty.They can pick a date and time and book an
appointment. When the booking is confirmed, the patient can immediately see it in their list.
This makes arranging visits fast and simple.
Implementation:
- Patients can view available doctors and book a time slot.
- Doctors’ availability is organized
11
CSCE3701 - Software Engineering (Fall 2025) Module Instructors:
Group Number: 01 Dr. Yasmine Afify
Milestone 1 Report TA Asmaa Hasan
3. View & Cancel Appointments
Patients can see all their upcoming appointments. They can cancel or choose a new time
through this system. The system updates the schedule right away. It keeps everyone’s
calendars clear and up to date.
Implementation:
- Display all upcoming appointments for the logged-in patient.
- Add cancel and rescheduler buttons next to each entry.
4. Patient Medical Records (View Only)
Patients can review their past diagnoses and notes, and doctors can look up a patient’s
history when needed. In this stage it’s read only to keep things simple.
Implementation:
- Simple table medical records with columns like patient ID, diagnosis, date.
- Doctors can search by patient ID to view previous diagnoses.
5. Doctor Availability Management
Doctors can set the days when they are available to see patients. Patients will only see times
that match a doctor’s current schedule.
Implementation:
- Each doctor can add or edit their available hours.
- The patient booking form filters by availability.


