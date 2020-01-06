using CoreWebApi.Controllers.v1;
using CoreWebApi.Core.Interface;
using Moq;

namespace CoreWebApi.Tests.Categories
{
    public class BaseTestModel
    {
        public CategoryController Init()
        {
            Mock<ICategoryService> categoriesRepositoryMock = new Mock<ICategoryService>();
            CategoryController model = new CategoryController(categoriesRepositoryMock.Object);

            return model;
        }
    }
}