
using System;

namespace HMS.Admin_Functionalities
{
    public class DoctorAvailability
    {
        public int AvailabilityID { get; set; }
        public int DoctorID { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
