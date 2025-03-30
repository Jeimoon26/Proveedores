using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using ProveedoresAPI;
using ProveedoresAPI.Domain;
using Xunit;

namespace ProveedoresAPI.Tests.IntegrationTests
{
    public class ProveedorControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProveedorControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
            AuthenticateAsync().Wait(); 
        }

        private async Task AuthenticateAsync()
        {
            var loginResponse = await _client.PostAsJsonAsync("/api/auth/login", new
            {
                Username = "admin",
                Password = "admin123"
            });

            var result = await loginResponse.Content.ReadFromJsonAsync<AuthResponse>();

            if (!string.IsNullOrEmpty(result?.Token))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", result.Token);
            }
        }

        private class AuthResponse
        {
            public string Token { get; set; }
        }

        [Fact]
        public async Task GetAll_EndpointReturnsSuccessAndCorrectContentType()
        {
            var response = await _client.GetAsync("/api/proveedor");
            response.EnsureSuccessStatusCode(); 
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Post_ValidProveedor_ReturnsCreated()
        {
            var nuevoProveedor = new Proveedor
            {
                NIT = "123456789",
                RazonSocial = "Proveedor HOLA MUNDO",
                Direccion = "Calle 123",
                Ciudad = "Bogotá",
                Departamento = "Cundinamarca",
                Correo = "proveedor@test.com",
                Activo = true,
                FechaCreacion = DateTime.UtcNow,
                NombreContacto = "Juan Pérez",
                CorreoContacto = "juan.perez@test.com"
            };

            var response = await _client.PostAsJsonAsync("/api/proveedor", nuevoProveedor);

            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
