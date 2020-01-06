using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Infrastructure.Entity;

namespace CoreWebApi.Core.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
    }
}