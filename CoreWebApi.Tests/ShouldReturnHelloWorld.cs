using System;
using System.Net.Http;
using System.Threading.Tasks;
using CoreWebApi.Controllers.v1;
using CoreWebApi.Core.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace CoreWebApi.Tests
{
    public class ShouldReturnHelloWorld : BaseTestModel
    {
        [Fact]
        public async Task ShouldReturnHelloWorldGet()
        {
            var client = ClientInit();
            
            // Send requests just as if you were going over the network
            var response = await client.GetAsync("/");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!", responseString);
        }
    }
}