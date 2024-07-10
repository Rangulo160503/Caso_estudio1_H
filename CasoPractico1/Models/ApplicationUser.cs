using Microsoft.AspNetCore.Identity;

namespace CasoPractico1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
