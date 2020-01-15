namespace CoreWebApi.Core.Dto.Requests
{
    public class ProductRequest
    {
        public int categoryId { get; set; }
        
        public decimal Price { get; set; }
        
        public string Description { get; set; }
    }
}