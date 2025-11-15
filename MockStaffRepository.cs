using System.Collections.Generic;
using System.Linq;

namespace HMS.Admin_Functionalities
{
    public class MockStaffRepository : IStaffRepository
    {
        private readonly List<Staff> _staffList = new();
        private int _nextId = 1;
        public void Add(Staff s)
        {
            if (s.StaffID == 0)
                s.StaffID = _nextId++;

            _staffList.Add(s);

            _nextId = _staffList.Max(x => x.StaffID) + 1;
        }

        public void ResetNextId()
        {
            _nextId = _staffList.Any() ? _staffList.Max(x => x.StaffID) + 1 : 1;
        }


        public void Update(Staff s)
        {
            var existing = _staffList.FirstOrDefault(x => x.StaffID == s.StaffID);
            if (existing != null)
            {
                existing.Username = s.Username;
                existing.Email = s.Email;
                existing.Department = s.Department;
                existing.Role = s.Role;
                existing.PasswordHash = s.PasswordHash;
                existing.Status = s.Status;
            }
        }

        public void Delete(int id)
        {
            var s = _staffList.FirstOrDefault(x => x.StaffID == id);
            if (s != null)
                _staffList.Remove(s);

            _nextId = _staffList.Any()
                ? _staffList.Max(x => x.StaffID) + 1
                : 1;
        }

        public IEnumerable<Staff> GetAll() => _staffList;
        public Staff? GetById(int id) => _staffList.FirstOrDefault(x => x.StaffID == id);
        public Staff? GetByUsername(string username) => _staffList.FirstOrDefault(x => x.Username == username);
    }
}
