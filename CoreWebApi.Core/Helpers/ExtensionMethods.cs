using System.Collections.Generic;
using System.Linq;
using CoreWebApi.Infrastructure.Entity;

namespace CoreWebApi.Core.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<ApplicationUser> WithoutPasswords(this IEnumerable<ApplicationUser> users)
        {
            return users.Select(x => x.WithoutPassword());
        }
        
        public static ApplicationUser WithoutPassword(this ApplicationUser user) {
            user.PasswordHash = null;
            return user;
        }
    }
}