using System.Security.Claims;
using System.Threading.Tasks;
using CoreWebApi.Infrastructure.Data;
using CoreWebApi.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Core.Helpers
{
    public class GetCurrentUser
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetCurrentUser(DataContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

 //       public async Task<ApplicationUser> GetUser()
   //     {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            //var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

            //return user;
     //   }
    }
}