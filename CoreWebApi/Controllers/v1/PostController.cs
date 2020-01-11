using System.Threading.Tasks;
using CoreWebApi.Contracts;
using CoreWebApi.Core.Dto.Requests;
using CoreWebApi.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers.v1
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost(ApiRoutes.Post.CreatePost)]
        public async Task<IActionResult> CreatePost([FromBody] PostRequest request)
        {
            var model = await _postService.CreatePostAsync(request.Text);
            if (model == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "create.post.error"
                });
            }

            return Ok(new
            {
                Success = true,
                Data = model
            });
        }

        [HttpGet(ApiRoutes.Post.GetAllPosts)]
        public async Task<IActionResult> GetAllPosts()
        {
            var model = await _postService.GetAllPostsAsync();

            return Ok(new
            {
                //Success = true,
                Data = model
            });
        }
    }
}