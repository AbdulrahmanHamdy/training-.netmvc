using progectmvc.Models;

namespace progectmvc.Repriditory
{
    public class Employeerep: IEmployeeReprository
    {
        Context context;
            public Employeerep(Context _context) 
        {
            context = _context;
        }
        public void Add(Employee obj)
        {
            
            context.Add(obj);
        }
        public void update(Employee obj)
        {
            context.Update(obj);
        }
        public void delete(int id)
        {
            Employee dept = Getbyid(id);
            context.Remove(dept);
        }
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }
        public Employee Getbyid(int id)
        {
            return context.Employee.FirstOrDefault(d => d.Id == id);
        }
        public void save()
        {
            context.SaveChanges();
        }
    }
}
