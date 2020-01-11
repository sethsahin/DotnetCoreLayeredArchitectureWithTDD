using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Infrastructure.Entity;

namespace CoreWebApi.Core.Interface
{
    public interface IPostService
    {
        Task<Post> CreatePostAsync(string text);
        Task<List<Post>> GetAllPostsAsync();
    }
}