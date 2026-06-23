using Abstracciones.API;
using Abstracciones.Flujo;
using Abstracciones.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase, IVehiculoController
    {
        private IVehiculoFlujo _vehiculoFlujo;
        private ILogger<IVehiculoController> _logger;

        public VehiculoController(IVehiculoFlujo vehiculoFlujo, ILogger<IVehiculoController> logger)
        {
            _vehiculoFlujo = vehiculoFlujo;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] VehiculoRequest vehiculo)
        {
            var result = await _vehiculoFlujo.Agregar(vehiculo);
            return CreatedAtAction(nameof(Obtener), new { Id = result }, result);
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] VehiculoRequest vehiculo)
        {
            var result = await _vehiculoFlujo.Editar(Id, vehiculo);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid Id)
        {
            var result = await _vehiculoFlujo.Eliminar(Id);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var result = await _vehiculoFlujo.Obtener();
            if (!result.Any()) {
                return NoContent();
            }
            
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid Id)
        {
            var result = await _vehiculoFlujo.Obtener(Id);
            return Ok(result);
        }
    }
}
