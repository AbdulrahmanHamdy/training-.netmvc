using progectmvc.Models;

namespace progectmvc.Repriditory
{
    public class Departmenrep: IDepartmentReprository
    {
        Context context;
        public Departmenrep(Context _context)
        {
            context = _context;
        }
        public void Add(Department obj) 
        {
            context.Add(obj);
        }
        public void update(Department obj)
        {
            context.Update(obj);
        }
        public void delete(int id) 
        {
            Department dept = Getbyid(id);
            context.Remove(dept);
        }
        public List<Department> GetAll() 
        {
            return context.Department.ToList();
        }
            public Department Getbyid(int id) 
        {
            return context.Department.FirstOrDefault(d => d.Id == id);
        }
        public void save() 
        {
            context.SaveChanges();  
        }
    }
}
