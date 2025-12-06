using System;
using System.Collections.Generic;

namespace HMS.Admin_Functionalities
{
    public interface IAppointmentRepository
    {
        int Add(Appointment appt);
        void Update(Appointment appt);
        void Cancel(int appointmentId);
        Appointment? GetById(int id);
        IEnumerable<Appointment> GetByDoctor(int doctorId, DateTime from, DateTime to);
        IEnumerable<Appointment> GetByPatient(int patientId);
    }
}
