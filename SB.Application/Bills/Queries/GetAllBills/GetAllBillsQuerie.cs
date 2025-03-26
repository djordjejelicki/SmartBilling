using MediatR;
using SB.Application.DTOs.Bill.Reperesentations;

namespace SB.Application.Bills.Queries.GetAllBills
{
    public class GetAllBillsQuerie : IRequest<List<BillRepresentation>>
    {
    }
}
