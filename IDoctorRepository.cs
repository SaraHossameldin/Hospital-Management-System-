using HMS.Login_Story;
using System.Collections.Generic;
namespace HMS.Doctor_Functionalities
{
    public interface IDoctorRepository
    {
        void Add(Doctor d);
        Doctor? GetByUsername(string username);
        IEnumerable<Doctor> GetAll();
        void UpdateStatus(int doctorId, StaffStatus status);
    }
}
