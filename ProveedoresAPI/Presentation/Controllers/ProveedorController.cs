using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProveedoresAPI.Application.Interfaces;
using ProveedoresAPI.Domain;

namespace ProveedoresAPI.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _proveedorService.GetAllAsync();
            return Ok(proveedores);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var proveedor = await _proveedorService.GetByIdAsync(id);
                if (proveedor == null)
                {
                    return NotFound(new { message = $"No se encontró un proveedor con el ID: {id}" });
                }
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error interno al obtener el proveedor.", error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Proveedor proveedor)
        {
            if (proveedor == null)
            {
                return BadRequest(new { message = "Los datos del proveedor no pueden estar vacíos." });
            }

            try
            {
                await _proveedorService.AddAsync(proveedor);
                return CreatedAtAction(nameof(GetById), new { id = proveedor.Id }, proveedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el proveedor.", error = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Proveedor proveedorActualizado)
        {
            if (proveedorActualizado == null)
            {
                return BadRequest(new { message = "Los datos del proveedor no pueden estar vacíos." });
            }

            if (id != proveedorActualizado.Id)
            {
                return BadRequest(new { message = "El ID proporcionado en la URL no coincide con el ID del proveedor." });
            }

            try
            {
                var proveedorExistente = await _proveedorService.GetByIdAsync(id);
                if (proveedorExistente == null)
                {
                    return NotFound(new { message = $"No se encontró un proveedor con el ID: {id}" });
                }

                await _proveedorService.UpdateAsync(id, proveedorActualizado);
                return Ok(new { message = "Proveedor actualizado correctamente.", proveedor = proveedorActualizado });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el proveedor.", error = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new { message = "El ID del proveedor es requerido." });
            }

            try
            {
                var proveedorExistente = await _proveedorService.GetByIdAsync(id);
                if (proveedorExistente == null)
                {
                    return NotFound(new { message = $"No se encontró un proveedor con el ID: {id}" });
                }

                await _proveedorService.DeleteAsync(id);
                return Ok(new { message = "Proveedor eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el proveedor.", error = ex.Message });
            }
        }

    }
}
