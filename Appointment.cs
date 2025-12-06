using System;

namespace HMS.Admin_Functionalities
{
    public enum AppointmentStatus { Booked, Canceled }

    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status { get; set; } = "Booked";
        public DateTime CreatedAt { get; set; }
    }
}
