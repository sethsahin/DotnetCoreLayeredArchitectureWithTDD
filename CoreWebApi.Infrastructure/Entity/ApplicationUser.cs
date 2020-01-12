using Microsoft.AspNetCore.Identity;

namespace CoreWebApi.Infrastructure.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}