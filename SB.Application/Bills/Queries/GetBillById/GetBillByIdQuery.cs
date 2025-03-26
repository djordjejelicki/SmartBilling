using MediatR;
using SB.Application.DTOs.Bill.Reperesentations;

namespace SB.Application.Bills.Queries.GetBillById
{
    public class GetBillByIdQuery : IRequest<BillRepresentation>
    {
        public Guid BillId { get; set; }
    }
}
