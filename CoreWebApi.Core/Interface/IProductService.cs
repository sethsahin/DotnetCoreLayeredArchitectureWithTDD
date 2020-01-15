using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Infrastructure.Entity;

namespace CoreWebApi.Core.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<bool> CreateProduct(Product product, string userId, int categoryId);
    }
}