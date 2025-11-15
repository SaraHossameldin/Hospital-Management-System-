namespace HMS.Admin_Functionalities
{
    public interface IAdminRepository
    {
        void Add(Admin a);
        Admin? GetByUsername(string username);
        IEnumerable<Admin> GetAll();
    }
}

