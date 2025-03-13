using BestRoute.Database.Contracts;
using BestRoute.Models;
using BestRoute.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BestRoute.UnitTests
{
    public class RouteServiceTests
    {
        private readonly Mock<IRouteRepository> _routeRepositoryMock;
        private RouteService _routeService;

        public RouteServiceTests()
        {
            _routeRepositoryMock = new Mock<IRouteRepository>();
            _routeService = new RouteService(_routeRepositoryMock.Object);
        }

        [Fact]
        public async Task FindCheapestRouteAsync_ShouldReturnCheapestRoute_WhenRoutesExist()
        {
            // Arrange
            var routes = new List<RouteEntity>
            {
                new() { Id = 1, Origin = "GRU", Destination = "BRC", Price = 10 },
                new() { Id = 2, Origin = "BRC", Destination = "SCL", Price = 5 },
                new() { Id = 3, Origin = "GRU", Destination = "CDG", Price = 75 },
                new() { Id = 4, Origin = "GRU", Destination = "SCL", Price = 20 },
                new() { Id = 5, Origin = "GRU", Destination = "ORL", Price = 56 },
                new() { Id = 4, Origin = "ORL", Destination = "CDG", Price = 5 },
                new() { Id = 5, Origin = "SCL", Destination = "ORL", Price = 20 }
            };

            _routeRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(routes);

            string origin = "GRU";
            string destination = "CDG";

            // Instância do serviço
            _routeService = new RouteService(_routeRepositoryMock.Object);

            // Act
            var (path, cost) = await _routeService.FindCheapestRouteAsync(origin: origin, destination: destination);

            // Assert
            Assert.Equal(["GRU", "BRC", "SCL", "ORL", "CDG"], path);
            Assert.Equal(40, cost);

            // Garante que o método foi chamado exatamente uma vez
            _routeRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task FindCheapestRouteAsync_WhenRouteNotFound_ShouldThrowException()
        {
            // Arrange
            _routeRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync([]);

            string origin = "AAA";
            string destination = "ZZZ";

            var routeService = new RouteService(_routeRepositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _routeService.FindCheapestRouteAsync(origin, destination));
        }
    }
}