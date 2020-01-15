using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Core.Interface;
using CoreWebApi.Infrastructure.Data;
using CoreWebApi.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Core.Repository
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _dataContext.Products
                .Include(c => c.Category)
                .Include(u => u.ApplicationUser)
                .SingleOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<bool> CreateProduct(Product product, string userId, int categoryId)
        {
            var category = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Id == categoryId);
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
            await _dataContext.Products.AddAsync(product);
            product.ApplicationUser = user;
            product.Category = category;

            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        
        
    }
}