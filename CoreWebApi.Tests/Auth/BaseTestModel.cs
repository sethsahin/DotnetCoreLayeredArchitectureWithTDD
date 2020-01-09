using CoreWebApi.Controllers.v1;
using CoreWebApi.Core.Interface;
using Moq;

namespace CoreWebApi.Tests.Auth
{
    public class BaseTestModel
    {
        public AuthController Init()
        {
            Mock<IAuthService> authRepositoryMock = new Mock<IAuthService>();
            AuthController model = new AuthController(authRepositoryMock.Object);

            return model;
        }
    }
}