using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Core.Interface;
using CoreWebApi.Infrastructure.Data;
using CoreWebApi.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Core.Repository
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dataContext;

        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _dataContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var model = await _dataContext.Categories.SingleOrDefaultAsync(x => x.Id == categoryId);

            return model;
        }
    }
}