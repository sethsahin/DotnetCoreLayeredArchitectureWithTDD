using System.Threading.Tasks;
using System.Web.Http;
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

        [Microsoft.AspNetCore.Mvc.HttpPost(ApiRoutes.Post.CreatePost)]
        public async Task<IActionResult> CreatePost([Microsoft.AspNetCore.Mvc.FromBody] PostRequest request)
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

        [Microsoft.AspNetCore.Mvc.HttpGet(ApiRoutes.Post.GetAllPosts)]
        public async Task<IActionResult> GetAllPosts()
        {
            var model = await _postService.GetAllPostsAsync();

            return Ok(new
            {
                //Success = true,
                Data = model
            });
        }

        [Microsoft.AspNetCore.Mvc.HttpGet(ApiRoutes.Post.GetPostById)]
        public async Task<IActionResult> GetPostById([FromRoute] GetPostByIdRequest request)
        {
            var model = await _postService.GetPostById(request.postId);

            if (model == null)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "post.not-found"
                });
            }

            return Ok(new
            {
                Success = true,
                Data = model
            });
        }
    }
}