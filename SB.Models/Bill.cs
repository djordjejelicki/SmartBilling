using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SB.Models
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public double TotalBillPrice
        {
            get
            {
                double price = 0;
                foreach (BillItem bi in BillItems!)
                {
                    price += bi.TotalPrice;
                }
                return price;
            }
        }
        public List<BillItem>? BillItems { get; set; }

        [ForeignKey("BillCustomer")]
        public Guid CustomerId { get; set; }
        public Customer? BillCustomer { get; set; }

        [ForeignKey("RegisterOfficer")]
        public Guid EmployeeId { get; set; }
        public Employee? RegisterOfficer { get; set; }

    }
}
