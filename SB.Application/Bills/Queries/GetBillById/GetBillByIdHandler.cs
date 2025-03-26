using MediatR;
using SB.Application.Contracts;
using SB.Application.DTOs.Bill.Reperesentations;

namespace SB.Application.Bills.Queries.GetBillById
{
    public class GetBillByIdHandler : IRequestHandler<GetBillByIdQuery, BillRepresentation>
    {
        private readonly IBillRepository _billRepository;

        public GetBillByIdHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<BillRepresentation> Handle(GetBillByIdQuery request, CancellationToken cancellationToken)
        {
            var b = await _billRepository.GetBillById(request.BillId);
            if(b != null)
            {
                return new BillRepresentation { CustomerId = b.CustomerId, Date = b.Date };
            }
            else
            {
                return new BillRepresentation { CustomerId = Guid.Empty };
            }
        }
    }
}
