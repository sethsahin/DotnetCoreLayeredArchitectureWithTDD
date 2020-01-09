using System.ComponentModel;
using CoreWebApi.Core.Dto.Requests;
using Xunit;

namespace CoreWebApi.Tests.Auth
{
    public class AuthUnitTest : BaseTestModel
    {
        [Fact]
        public void Fact_PostLoginAsync()
        {
            var model = Init();

            var request = new AuthRequest();
            request.Email = "deneme@deneme.com";
            request.Password = "Password123--";
            var result = model.LoginAsync(request);
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Fact_PostRegisterAsync()
        {
            var model = Init();
            var request = new AuthRequest();
            request.Email = "deneme@deneme.com";
            request.Password = "Password123--";

            var result = model.RegisterAsync(request);
            
            Assert.NotNull(result);
        }
    }
}