using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB.Models
{
    public class BillItem
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        
        [NotMapped]
        public double TotalPrice
        {
            get 
            {
                return BillProduct!.Price * Quantity;
            }
        }
        
        [ForeignKey("BillProduct")]
        public Guid ProductId { get; set; }
        public Product? BillProduct { get; set; }

        [ForeignKey("Bill")]
        public Guid BillId { get; set; }
        public Bill? Bill { get; set; }
        
    }
}
