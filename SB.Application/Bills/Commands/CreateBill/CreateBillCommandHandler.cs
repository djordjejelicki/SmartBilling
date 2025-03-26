using MediatR;
using SB.Application.Contracts;
using SB.Application.DTOs.Bill.Reperesentations;
using SB.Models;

namespace SB.Application.Bills.Commands.CreateBill
{
    public class CreateBillCommandHandler : IRequestHandler<CreateBillCommand, BillRepresentation>
    {
        private readonly IBillRepository? _billRepository;
        public CreateBillCommandHandler(IBillRepository? billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<BillRepresentation> Handle(CreateBillCommand request, CancellationToken cancellationToken)
        {
            var bill = new Bill
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                Date = request.BillDate,
                EmployeeId = request.EmployeeId
            };
            var result = await _billRepository!.CreateBill(bill);
            return new BillRepresentation { Date = result.Date, CustomerId = result.CustomerId };

        }
    }
}
