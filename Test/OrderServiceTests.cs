using CrudeMobileApp.Model;
using CrudeMobileApp.Repositories;
using CrudeMobileApp.Services;
using Moq;

namespace Test
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IDetailOrderRepository> _detailOrderRepositoryMock;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _detailOrderRepositoryMock = new Mock<IDetailOrderRepository>();
            _orderService = new OrderService(_orderRepositoryMock.Object, _detailOrderRepositoryMock.Object);
        }

        [Fact]
        public async Task AddOrderAsync_ShouldAddOrderAndDetails()
        {
            // Arrange
            var order = new Order { OrderId = 1 };
            var orderDetails = new List<DetailOrder>
            {
                new() { OrderId = 1, ProductId = "1", Quantity = 10 }
            };

            // Act
            await _orderService.AddOrderAsync(order, orderDetails);

            // Assert
            _orderRepositoryMock.Verify(repo => repo.AddAsync(order), Times.Once);
            _detailOrderRepositoryMock.Verify(repo => repo.AddRangeAsync(orderDetails), Times.Once);
        }

        [Fact]
        public async Task GetOrdersWithCustomerAsync_ShouldReturnOrdersWithCustomers()
        {
            // Arrange
            var orders = new List<Order>
            {
                new() { OrderId = 1, CustomerId = "1" }
            };

            _orderRepositoryMock.Setup(repo => repo.GetOrdersWithCustomersAsync()).ReturnsAsync(orders);

            // Act
            var result = await _orderService.GetOrdersWithCustomerAsync();

            // Assert
            Assert.Equal(orders, result);
        }
    }
}