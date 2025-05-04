using progectmvc.Models;

namespace progectmvc.Repriditory
{
    public interface IDepartmentReprository
    {
       

        public void Add(Department obj);

        public void update(Department obj);

        public void delete(int id);

        public List<Department> GetAll();
        public Department Getbyid(int id);

        public void save();
    }
}
