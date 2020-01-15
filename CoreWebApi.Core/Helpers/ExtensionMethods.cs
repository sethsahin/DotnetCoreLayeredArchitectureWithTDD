using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using CoreWebApi.Infrastructure.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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