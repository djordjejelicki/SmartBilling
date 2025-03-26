using MediatR;
using SB.Application.DTOs.BillItem.Representations;

namespace SB.Application.BillItems.Commands.CreateBillItem
{
    public class CreateBillItemCommand : IRequest<BillItemRepresentation>
    {
        public Guid BillId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
