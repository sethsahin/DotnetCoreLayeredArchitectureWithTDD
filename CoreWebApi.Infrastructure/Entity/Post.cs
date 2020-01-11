using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Infrastructure.Entity
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}