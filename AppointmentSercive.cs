using System;

namespace HMS.Admin_Functionalities
{
    public class AppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        public (bool Success, string Message) BookAppointment(int patientId, int doctorId, DateTime start, DateTime end)
        {
            try
            {
                var appt = new Appointment
                {
                    PatientID = patientId,
                    DoctorID = doctorId,
                    StartAt = start,
                    EndAt = end
                };
                _repo.Add(appt);
                return (true, "Appointment booked successfully.");
            }
            catch (Exception ex)
            {
                return (false, $"Error booking appointment: {ex.Message}");
            }
        }

        public (bool Success, string Message) CancelAppointment(int apptId, int patientId)
        {
            var appt = _repo.GetById(apptId);
            if (appt == null || appt.PatientID != patientId)
                return (false, "Appointment not found or unauthorized.");

            _repo.Cancel(apptId);
            return (true, "Appointment canceled successfully.");
        }

        public (bool Success, string Message) RescheduleAppointment(int apptId, int patientId, DateTime newStart, DateTime newEnd)
        {
            var appt = _repo.GetById(apptId);
            if (appt == null || appt.PatientID != patientId)
                return (false, "Appointment not found or unauthorized.");

            appt.StartAt = newStart;
            appt.EndAt = newEnd;
            appt.Status = "Rescheduled";

            _repo.Update(appt);
            return (true, "Appointment rescheduled successfully.");
        }
    }
}
