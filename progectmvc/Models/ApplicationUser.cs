using Microsoft.AspNetCore.Identity;

namespace progectmvc.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
