namespace SB.API.Requests.BillRequests
{
    public class CreateBillRequest
    {
        public Guid CustomerId { get; set; }
        public DateTime BillDate { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
