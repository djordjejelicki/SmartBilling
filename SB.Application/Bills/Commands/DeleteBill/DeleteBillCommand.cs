using MediatR;
using SB.Application.DTOs.Bill.Messages;

namespace SB.Application.Bills.Commands.DeleteBill
{
    public class DeleteBillCommand : IRequest<BillDeletingMessage>
    {
        public Guid BillId { get; set; }
    }
}
