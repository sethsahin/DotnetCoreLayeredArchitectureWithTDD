using System.Threading.Tasks;
using CoreWebApi.Contracts;
using CoreWebApi.Core.Dto.Requests;
using CoreWebApi.Core.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers.v1
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<IActionResult> RegisterAsync([FromBody] AuthRequest request)
        {
            var model = await _authService.RegisterAsync(request.Email, request.Password);

            if (model == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Error = "auth.register.error"
                });
            }

            return Ok(new
            {
                Success = true,
                Data = model
            });
        }

        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> LoginAsync([FromBody] AuthRequest request)
        {
            var model = await _authService.LoginAsync(request.Email, request.Password);

            if (model == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Error = "auth.login.error"
                });
            }

            return Ok(new
            {
                Success = true,
                Data = model
            });
        }
    }
}