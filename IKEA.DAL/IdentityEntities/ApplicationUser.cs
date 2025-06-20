using Microsoft.AspNetCore.Identity;

namespace IKEA.DAL.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string?  Fname { get; set; } 
        public string?  Lname { get; set; }
        public bool  IsAgree { get; set; }
    }
}
