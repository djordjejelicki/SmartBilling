using MediatR;
using SB.Application.DTOs.BillItem.Messages;

namespace SB.Application.BillItems.Commands.DeleteBillItem
{
    public class DeleteBillItemCommand : IRequest<BillItemDeletingMessage>
    {
        public Guid BillItemId { get; set; }
    }
}
