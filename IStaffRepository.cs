namespace HMS.Admin_Functionalities
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAll();
        Staff? GetById(int id);
        Staff? GetByUsername(string username);
        void Add(Staff staff);
        void Update(Staff staff);
        void Delete(int id);
    }
}
