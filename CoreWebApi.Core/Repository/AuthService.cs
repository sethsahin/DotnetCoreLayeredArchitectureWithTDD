using System.Threading.Tasks;
using CoreWebApi.Core.Interface;
using CoreWebApi.Infrastructure.Data;
using CoreWebApi.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity;

namespace CoreWebApi.Core.Repository
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext _dataContext;

        public AuthService(DataContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> RegisterAsync(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                return null;
            }
            
            var newUser = new ApplicationUser
            {
                Email = email,
                UserName = email
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return null;
            }

            return newUser;
        }

        public async Task<ApplicationUser> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!userHasValidPassword)
            {
                return null;
            }

            return user;
        }
    }
}