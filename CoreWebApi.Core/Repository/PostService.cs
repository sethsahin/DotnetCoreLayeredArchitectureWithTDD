using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Core.Interface;
using CoreWebApi.Infrastructure.Data;
using CoreWebApi.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Core.Repository
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Post> CreatePostAsync(string text)
        {
            var model = new Post
            {
                Text = text
            };

            var createdPost = await _dataContext.Posts.AddAsync(model);
            await _dataContext.SaveChangesAsync();
            if (createdPost == null)
            {
                return null;
            }

            return model;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            var model = await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);

            return model;
        }
    }
}