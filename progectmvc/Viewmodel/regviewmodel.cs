using System.ComponentModel.DataAnnotations;

namespace progectmvc.Viewmodel
{
    public class regviewmodel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name ="Comfirm Password")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
        public string Address { get; set; }
    }
}
