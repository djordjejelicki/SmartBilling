using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SB.API.Controllers;
using SB.API.Requests.BillItemRequests;
using SB.Application.BillItems.Commands.CreateBillItem;
using SB.Application.BillItems.Commands.DeleteBillItem;
using SB.Application.DTOs.BillItem.Messages;
using SB.Application.DTOs.BillItem.Representations;

namespace SB.Testing
{
    public class BillItemsControlerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BillItemsController _controller;

        public BillItemsControlerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new BillItemsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateBillItem_ShouldReturnOk_WhenSuccessful()
        {
            //Arrange
            var request = new CreateBillItemRequest
            {
                BillId = new Guid("ca4c3464-bf08-4a24-951c-b3e546c24df1"),
                ItemID = new Guid("113e7663-2cac-45c6-b349-b6189d9c3f4d"),
                Quantity = 2
            };
            var expectedResponse = new BillItemRepresentation
            {
                BillId = request.BillId,
                ProductName = "Bicycle",
                TotalPrice = 500
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateBillItemCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            //Act
            var result = await _controller.CreateBillItem(request);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseMessage = Assert.IsType<string>(okResult.Value);
            Assert.Contains($"Created bill item for {expectedResponse.ProductName}", responseMessage);
        }

        [Fact]
        public async Task DeleteBillItem_ShouldReturnOk_WhenSuccessful()
        {
            //Arrange
            var request = new DeleteBillItemRequest
            {
                BillItemId = new Guid("72333650-a184-407c-bfeb-7b7274c700d8")
            };
            var expectedResponse = new BillItemDeletingMessage
            {
                Succsess = true,
                Message = $"bill item: {request.BillItemId} successfully deleted from bill"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBillItemCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            //Act
            var result = await _controller.DeleteBillItem(request);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseMessage = Assert.IsType<string>(okResult.Value);
            Assert.Contains(expectedResponse.Message, responseMessage);
        }

        [Fact]
        public async Task DeleteBillItem_ShouldReturnBadRequest_WhenUnsuccessful()
        {
            //Arrange
            var request = new DeleteBillItemRequest
            {
                BillItemId = Guid.NewGuid()
            };
            var expectedResponse = new BillItemDeletingMessage
            {
                Succsess = false,
                Message = $"bill item: {request.BillItemId} does not exist in data base"
            };
            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBillItemCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedResponse);

            //Act
            var result = await _controller.DeleteBillItem(request);

            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            var responseMessage = Assert.IsType<string>(badResult.Value);
            Assert.Contains(expectedResponse.Message, responseMessage);
        }
    }
}
