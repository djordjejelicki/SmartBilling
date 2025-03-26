using MediatR;
using SB.Application.DTOs.Bill.Reperesentations;

namespace SB.Application.Bills.Commands.CreateBill
{
    public class CreateBillCommand : IRequest<BillRepresentation>
    {
        public Guid CustomerId { get; set; }
        public DateTime BillDate { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
