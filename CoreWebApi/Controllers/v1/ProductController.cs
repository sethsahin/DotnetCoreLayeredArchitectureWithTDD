using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreWebApi.Contracts;
using CoreWebApi.Core.Dto.Requests;
using CoreWebApi.Core.Helpers;
using CoreWebApi.Core.Interface;
using CoreWebApi.Infrastructure.Data;
using CoreWebApi.Infrastructure.Entity;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Controllers.v1
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ProductController(IProductService productService, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet(ApiRoutes.Product.GetAllProducts)]
        public async Task<IActionResult> GetAllProducts()
        {
            var model = await _productService.GetAllProducts();

            return Ok(new
            {
                Succes = true,
                Data = model
            });
        }

        [HttpPost(ApiRoutes.Product.CreateProduct)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
        {
            var userId = HttpContext.User.Identity.Name;
            Console.WriteLine(userId);
            var model = new Product
            {
                Price = request.Price,
                Description = request.Description,
            };

            var createdProduct = _productService.CreateProduct(model, userId, request.categoryId);

            if (await createdProduct == false)
            {
                return BadRequest(new
                {
                    Success = false,
                    Error = "product.create"
                });
            }

            return Ok(new
            {
                Success = true,
                Data = model
            });
        }
        
        public async Task<string> GetUser()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            return user.Id;
        }
        
    }
}