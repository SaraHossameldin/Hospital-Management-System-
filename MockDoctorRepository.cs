using HMS.Login_Story;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Doctor_Functionalities
{
    public class MockDoctorRepository : IDoctorRepository
    {
        private readonly List<Doctor> _doctors = new();

        public void Add(Doctor d)
        {
            _doctors.Add(d);
        }

        public Doctor? GetByUsername(string username)
        {
            return _doctors.FirstOrDefault(d => d.Username == username);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctors;
        }

        public void UpdateStatus(int doctorId, StaffStatus status)
        {
            var doc = _doctors.FirstOrDefault(d => d.DoctorID == doctorId);
            if (doc != null)
            {
                doc.Status = status;
            }
        }
    }
}
