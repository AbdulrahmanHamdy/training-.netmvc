using progectmvc.Models;

namespace progectmvc.Repriditory
{
    public interface IEmployeeReprository
    {


        public void Add(Employee obj);

        public void update(Employee obj);

        public void delete(int id);

        public List<Employee> GetAll();
        public Employee Getbyid(int id);

        public void save();
        
    }
}
