using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CoreWebApi.Contracts;
using CoreWebApi.Core.Dto.Requests;
using CoreWebApi.Core.Dto.Responses;
using CoreWebApi.Infrastructure.Entity;
using FluentAssertions;
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

        [Fact]
        public async Task CreatePostShouldReturnSuccess()
        {
            var client = ClientInit();
            
            // Send Request
            var model = await client.PostAsJsonAsync(ApiRoutes.Post.CreatePost, "test");
            var response = model.Content.ReadAsAsync<PostResponse>();
            var responseModel = await client.GetAsync(ApiRoutes.Post.GetPostById.Replace("{postId}", response.Id.ToString()));
            
            // Assert
            responseModel.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}