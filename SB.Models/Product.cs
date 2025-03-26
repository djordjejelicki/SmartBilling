using System.ComponentModel.DataAnnotations;

namespace SB.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set;}
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
    }
}
