using MediatR;
using Microsoft.AspNetCore.Mvc;
using SB.API.Requests.BillRequests;
using SB.Application.Bills.Commands.CreateBill;
using SB.Application.Bills.Commands.DeleteBill;
using SB.Application.Bills.Queries.GetAllBills;
using SB.Application.Bills.Queries.GetBillById;
using SB.Application.DTOs.Bill.Reperesentations;

namespace SB.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(CreateBillRequest request)
        {
            var b = await _mediator.Send(new CreateBillCommand
            {
                CustomerId = request.CustomerId,
                BillDate = request.BillDate,
                EmployeeId = request.EmployeeId
                
            });

            return Ok($"Created Bill at: {b.Date} for customer: {b.CustomerId}");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBill(DeleteBillRequest request)
        {
            var b = await _mediator.Send(new DeleteBillCommand
            {
                BillId = request.BillId
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

        [HttpGet("id")]
        public async Task<IActionResult> GetBillById(string Id)
        {
            var b = await _mediator.Send(new GetBillByIdQuery { BillId = new Guid(Id) });
            if(b.CustomerId != Guid.Empty)
            {
                return Ok($"Bill is from customer: {b.CustomerId} at date: {b.Date}");
            }
            else
            {
                return BadRequest($"There is no bill with id: {Id}");
            }
        }

        [HttpGet]
        public async Task<List<BillRepresentation>> GetAllBills()
        {
            var result = await _mediator.Send(new GetAllBillsQuerie());
            return result;
        }
    }
}
