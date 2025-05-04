using System.ComponentModel.DataAnnotations;

namespace progectmvc.Viewmodel
{
    public class Loginuserviewmodel
    {
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Remember Me!!")]
        public bool RememberMe { get; set; }
    }
}
