using HMS.Helpers;
using HMS.Login_Story;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Admin_Functionalities
{
    public class StaffService
    {
        private readonly IStaffRepository _repo;

        public StaffService(IStaffRepository repo) => _repo = repo;

        public void Add(Staff s)
        {
            if (s.StaffID == 0) s.StaffID = 0; // keep 0 for mock repo
            _repo.Add(s);

            // assign actual ID back
            var addedStaff = _repo.GetAll().LastOrDefault();
            if (addedStaff != null) s.StaffID = addedStaff.StaffID;
        }

        public void Update(Staff s) => _repo.Update(s);
        public void Delete(int id) => _repo.Delete(id);
        public IEnumerable<Staff> GetAll() => _repo.GetAll();
        public Staff? GetById(int id) => _repo.GetById(id);
        public Staff? GetByUsername(string username) => _repo.GetByUsername(username);

        public Result Activate(int id, string username, string password)
        {
            var staff = _repo.GetById(id);
            if (staff == null) return Result.Fail("Staff not found");

            staff.Username = username;
            staff.PasswordHash = AuthService.HashPassword(password);
            staff.Status = StaffStatus.Active;

            _repo.Update(staff);
            return Result.Ok("Staff activated");
        }
    }
}

