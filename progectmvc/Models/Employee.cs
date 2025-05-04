using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace progectmvc.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Requred]
        [MinLength(3,ErrorMessage ="ake it taller bitch")]
        public string Name { get; set; }
        public double Salary { get; set; }

        public string Joptitle { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }

    internal class RequredAttribute : Attribute
    {
    }
}
