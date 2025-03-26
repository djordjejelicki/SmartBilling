using System.ComponentModel.DataAnnotations;

namespace SB.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public List<Bill>? Bills { get; set; }
    }
}
