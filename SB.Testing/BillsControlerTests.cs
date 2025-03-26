using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SB.API.Controllers;
using SB.API.Requests.BillRequests;
using SB.Application.Bills.Commands.CreateBill;
using SB.Application.Bills.Commands.DeleteBill;
using SB.Application.Bills.Queries.GetBillById;
using SB.Application.DTOs.Bill.Messages;
using SB.Application.DTOs.Bill.Reperesentations;

namespace SB.Testing
{
    public class BillsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BillsController _controller;


        public BillsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new BillsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateBill_ShouldReturnOk_WithCreatedMessage()
        {
            //Arrange
            var request = new CreateBillRequest
            {
                CustomerId = new Guid("f3b1d4a8-7c2d-4f84-81df-2a5e3b671e1b"),
                BillDate = DateTime.UtcNow,
                EmployeeId = new Guid("20b5d218-e87b-42cc-9568-ef69ab1b2945")
            };

            var expectedResponse = new BillRepresentation
            {
                Date = request.BillDate,
                CustomerId = request.CustomerId
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBillCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            //Act
            var result = await _controller.CreateBill(request);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseMessage = Assert.IsType<string>(okResult.Value);
            Assert.Contains($"Created Bill at: {expectedResponse.Date} for customer: {expectedResponse.CustomerId}", responseMessage);
        }

        [Fact]
        public async Task DeleteBill_ShouldReturnOk_WhenSuccessful()
        {
            //Arange
            var request = new DeleteBillRequest { BillId = new Guid("ca4c3464-bf08-4a24-951c-b3e546c24df1") };
            var expectedResponse = new BillDeletingMessage
            {
                Succsess = true,
                Message = $"bill: {request.BillId} successfully deleted"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBillCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);
            
            //Act
            var result = await _controller.DeleteBill(request);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseMessage = Assert.IsType<string>(okResult.Value);
            Assert.Equal(expectedResponse.Message, responseMessage);
        }

        [Fact]
        public async Task DeleteBill_ShouldReturnBadRequest_WhenUnsuccessful()
        {
            //Arange
            var request = new DeleteBillRequest { BillId = Guid.NewGuid() };
            var expectedResponse = new BillDeletingMessage
            {
                Succsess = false,
                Message = $"bill: {request.BillId} does not exist in data base"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBillCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            //Act
            var result = await _controller.DeleteBill(request);

            //Assert
            var BadResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseMessage = Assert.IsType<string>(BadResult.Value);
            Assert.Equal(expectedResponse.Message, responseMessage);
        }

        [Fact]
        public async Task GetBillById_ShouldReturnOk_WhenBillExists()
        {
            //Arange
            var request = new GetBillByIdQuery { BillId = new Guid("ca4c3464-bf08-4a24-951c-b3e546c24df1") };
            string dateString = "2025-03-24 15:44:30.832+01";
            DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(dateString);
            var expectedResponse = new BillRepresentation
            {
                CustomerId = new Guid("6b29fc40-68a2-4b80-91b4-914a5f2b7f04"),
                Date = dateTimeOffset.DateTime
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBillByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            //Act
            var result = await _controller.GetBillById(request.BillId.ToString());

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseMessage = Assert.IsType<string>(okResult.Value);
            Assert.Contains($"Bill is from customer: {expectedResponse.CustomerId}", responseMessage);
        }

        [Fact]
        public async Task GetBillById_ShouldReturnBadRequest_WhenBillDoesNotExist()
        {
            //Arrange
            var billId = Guid.NewGuid();
            var expectedResponse = new BillRepresentation()
            {
                CustomerId = Guid.Empty,
                Date = default
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBillByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            //Act
            var result = await _controller.GetBillById(billId.ToString());

            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseMessage = Assert.IsType<string>(badResult.Value);
            Assert.Contains($"There is no bill with id: {billId}", responseMessage);
        }
    }
}
