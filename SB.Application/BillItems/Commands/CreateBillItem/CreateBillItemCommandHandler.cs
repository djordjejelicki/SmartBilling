using MediatR;
using SB.Application.Contracts;
using SB.Application.DTOs.BillItem.Representations;
using SB.Models;

namespace SB.Application.BillItems.Commands.CreateBillItem
{
    public class CreateBillItemCommandHandler : IRequestHandler<CreateBillItemCommand, BillItemRepresentation>
    {
        private IBillItemRepository _billItemRepository;

        public CreateBillItemCommandHandler(IBillItemRepository billItemRepository)
        {
            _billItemRepository = billItemRepository;
        }

        public async Task<BillItemRepresentation> Handle(CreateBillItemCommand request, CancellationToken cancellationToken)
        {
            BillItem billItem = new BillItem
            {
                Id = Guid.NewGuid(),
                BillId = request.BillId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            var newItem = await _billItemRepository.CreateBillItem(billItem);
            return newItem;

        }
    }
}
