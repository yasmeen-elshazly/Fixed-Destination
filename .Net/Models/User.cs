using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User : IdentityUser
    {
        public int NoofVisits { get; set; }
       
    }
}
