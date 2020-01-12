namespace CoreWebApi.Core.Dto.Requests
{
    public class PostRequest
    {
        public string Text { get; set; }
    }

    public class GetPostByIdRequest
    {
        public int postId { get; set; }
    }
}