using System.ComponentModel.DataAnnotations;

namespace progectmvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Requred]
        [MinLength(3, ErrorMessage = "make it taller bitch")]
        public string Name { get; set; }
        public string Image{ get; set; }


    }
}
