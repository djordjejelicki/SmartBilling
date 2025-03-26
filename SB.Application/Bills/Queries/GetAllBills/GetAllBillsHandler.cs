using AutoMapper;
using MediatR;
using SB.Application.Contracts;
using SB.Application.DTOs.Bill.Reperesentations;
using SB.Models;

namespace SB.Application.Bills.Queries.GetAllBills
{
    public class GetAllBillsHandler : IRequestHandler<GetAllBillsQuerie, List<BillRepresentation>>
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public GetAllBillsHandler(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }
        public async Task<List<BillRepresentation>> Handle(GetAllBillsQuerie request, CancellationToken cancellationToken)
        {
            var bills = await _billRepository.GetAllBills();
            var result = _mapper.Map<List<Bill>, List<BillRepresentation>>(bills!);
            return result;
        }
    }
}
