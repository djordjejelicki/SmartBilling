namespace SB.Application.DTOs.BillItem.Representations
{
    public class BillItemRepresentation
    {
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public string? ProductName { get; set; }
        public double TotalPrice { get; set; }

    }
}
