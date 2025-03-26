namespace SB.API.Requests.BillItemRequests
{
    public class CreateBillItemRequest
    {
        public Guid BillId { get; set; }
        public Guid ItemID { get; set; }
        public int Quantity { get; set; }

    }
}
