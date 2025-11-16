using HMS.Login_Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Receptionist_Not_Completed
{
    public interface IReceptionistRepository
    {
        void Add(Receptionist r);
        Receptionist? GetByUsername(string username);
        IEnumerable<Receptionist> GetAll();
        void UpdateStatus(int receptionistId, StaffStatus status);
    }

}
