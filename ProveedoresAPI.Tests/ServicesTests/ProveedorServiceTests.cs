using Moq;
using ProveedoresAPI.Application.Interfaces;
using ProveedoresAPI.Application.Services;
using ProveedoresAPI.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProveedoresAPI.Tests.ServicesTests
{
    public class ProveedorServiceTests
    {
        private readonly Mock<IProveedorRepository> _mockRepo;
        private readonly ProveedorService _service;

        public ProveedorServiceTests()
        {
            _mockRepo = new Mock<IProveedorRepository>();
            _service = new ProveedorService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsProveedores()
        {
            var proveedores = new List<Proveedor>
            {
                new Proveedor { Id = "1", RazonSocial = "Proveedor 1" },
                new Proveedor { Id = "2", RazonSocial = "Proveedor 2" }
            };
            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(proveedores);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
