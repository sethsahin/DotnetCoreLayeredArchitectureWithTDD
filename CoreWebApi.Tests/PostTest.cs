using System.Net;
using System.Threading.Tasks;
using CoreWebApi.Contracts;
using CoreWebApi.Infrastructure.Entity;
using Xunit;

namespace CoreWebApi.Tests
{
    public class PostTest : BaseTestModel
    {
        [Fact]
        public async Task GetPostListShouldReturnSuccesss()
        {
            var client = ClientInit();
                
            // Send request
            var response = await client.GetAsync(ApiRoutes.Post.GetAllPosts);
                            
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = (response.StatusCode == HttpStatusCode.OK);
            Assert.Equal(statusCode, response.IsSuccessStatusCode);
        }
    }
}