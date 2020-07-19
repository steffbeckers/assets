using Microsoft.AspNetCore.Identity;

namespace Assets.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
