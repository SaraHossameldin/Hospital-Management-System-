using System.Collections.Generic;
using System.Linq;

namespace HMS.Admin_Functionalities
{
    public class MockAdminRepository : IAdminRepository
    {
        private readonly List<Admin> _admins = new();

        public void Add(Admin a)
        {
            _admins.Add(a);
        }

        public Admin? GetByUsername(string username)
        {
            return _admins.FirstOrDefault(a => a.Username == username);
        }

        public IEnumerable<Admin> GetAll()
        {
            return _admins;
        }
    }
}

