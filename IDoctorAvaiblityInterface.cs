using System.Collections.Generic;

namespace HMS.Admin_Functionalities
{
    public interface IDoctorAvailabilityRepository
    {
        void Add(DoctorAvailability a);
        void Remove(int availabilityId);
        void Update(DoctorAvailability a);
        DoctorAvailability? GetById(int id);

        // Unified: no from/to
        IEnumerable<DoctorAvailability> GetByDoctor(int doctorId);
        IEnumerable<DoctorAvailability> GetAvailableByDoctor(int doctorId);
        IEnumerable<DoctorAvailability> GetDoctorsWithAvailability();
        IEnumerable<DoctorAvailability> GetAllAvailable();
    }
}
