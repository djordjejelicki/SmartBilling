using MediatR;
using SB.Application.Contracts;
using SB.Application.DTOs.Bill.Messages;

namespace SB.Application.Bills.Commands.DeleteBill
{
    public class DeleteBillCommandHandler : IRequestHandler<DeleteBillCommand, BillDeletingMessage>
    {
        private readonly IBillRepository _billRepository;

        public DeleteBillCommandHandler(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<BillDeletingMessage> Handle(DeleteBillCommand request, CancellationToken cancellationToken)
        {
            var result = await _billRepository.DeleteBill(request.BillId);
            return result;
        }
    }
}
