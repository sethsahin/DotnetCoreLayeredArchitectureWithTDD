using Xunit;

namespace CoreWebApi.Tests.Categories
{
    public class CategoryUnitTestController : BaseTestModel
    {
        [Fact]
        public void Fact_GetCategories()
        {
            var model = Init();
            
            var result = model.GetCategories();
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Fact_GetCategoriesById()
        {
            var model = Init();

            var result = model.GetCategoryById(1);
            
            Assert.NotNull(result);
        }
    }
}