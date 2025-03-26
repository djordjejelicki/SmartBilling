using MediatR;
using SB.Application.Contracts;
using SB.Application.DTOs.BillItem.Messages;

namespace SB.Application.BillItems.Commands.DeleteBillItem
{
    public class DeleteBillItemCommandHandler : IRequestHandler<DeleteBillItemCommand, BillItemDeletingMessage>
    {
        private readonly IBillItemRepository _billItemRepository;

        public DeleteBillItemCommandHandler(IBillItemRepository billItemRepository)
        {
            _billItemRepository = billItemRepository;
        }

        public async Task<BillItemDeletingMessage> Handle(DeleteBillItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _billItemRepository.DeleteBillItem(request.BillItemId);
            return result;
        }
    }
}
