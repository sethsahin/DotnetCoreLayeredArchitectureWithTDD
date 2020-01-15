using System.ComponentModel.DataAnnotations;

namespace CoreWebApi.Infrastructure.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        public decimal Price { get; set; }
        
        public string Description { get; set; }
        
        public Category Category { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
    }
}