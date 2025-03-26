using MediatR;
using Microsoft.AspNetCore.Mvc;
using SB.API.Requests.BillItemRequests;
using SB.Application.BillItems.Commands.CreateBillItem;
using SB.Application.BillItems.Commands.DeleteBillItem;

namespace SB.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BillItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBillItem(CreateBillItemRequest request)
        {
            var b = await _mediator.Send(new CreateBillItemCommand
            {
                BillId = request.BillId,
                ProductId = request.ItemID,
                Quantity = request.Quantity
            });

            return Ok($"Created bill item for {b.ProductName} TotalPrice: {b.TotalPrice}");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBillItem(DeleteBillItemRequest request)
        {
            var b = await _mediator.Send(new DeleteBillItemCommand
            {
                BillItemId = request.BillItemId
            });

            if (b.Succsess)
            {
                return Ok(b.Message);
            }
            else
            {
                return BadRequest(b.Message);
            }
        }
    }
}
