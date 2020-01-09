using System.Threading.Tasks;
using CoreWebApi.Infrastructure.Entity;

namespace CoreWebApi.Core.Interface
{
    public interface IAuthService
    {
        Task<ApplicationUser> RegisterAsync(string email, string password);
        Task<ApplicationUser> LoginAsync(string email, string password);
    }
}