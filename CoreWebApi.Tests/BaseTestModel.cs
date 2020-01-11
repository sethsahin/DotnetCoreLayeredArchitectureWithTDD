using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;

namespace CoreWebApi.Tests
{
    public class BaseTestModel
    {
        public HttpClient ClientInit()
        {
            // Build your "app"
            var webHostBuilder = new WebHostBuilder()
                .Configure(app => app.Run(async ctx => 
                    await ctx.Response.WriteAsync("Hello World!")
                ));
            
            // Configure the in-memory test server, and create an HttpClient for interacting with it
            var server = new TestServer(webHostBuilder);
            HttpClient client = server.CreateClient();

            return client;
        }
    }
}