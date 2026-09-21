using BackendWebApp.Data.AccesoDatos;
using BackendWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [EnableCors("AngularPolicy")]
    public class BackEjecucionesController : ControllerBase
    {
        [HttpGet]
        [HttpGet("Listar")]
        [HttpGet("Index")]
        public IActionResult Listar()
        {
            var model = new DADetalleEjecuciones();
            var datos = model.GetDetalleOperacion();

            return Ok(datos);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var model = new DADetalleEjecuciones();
            var item = model.GetDetalleOperacionById(id);

            if (item == null)
            {
                return NotFound(new { mensaje = $"No se encontró la operación con ID {id}" });
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] DetalleOperacion entidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entidad.IdDetalleOperacion = 0;
            entidad.Igv = entidad.Importe * 0.18f;
            entidad.Total = entidad.Importe + entidad.Igv;

            var model = new DADetalleEjecuciones();
            var nuevoId = model.InsertDetalleOperacion(entidad);

            if (nuevoId <= 0)
            {
                return BadRequest(new { mensaje = "No se pudo registrar la operación." });
            }

            entidad.IdDetalleOperacion = nuevoId;
            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoId }, entidad);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] DetalleOperacion entidad)
        {
            if (id != entidad.IdDetalleOperacion)
            {
                return BadRequest(new { mensaje = "El ID de la ruta no coincide con el cuerpo de la solicitud." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entidad.Igv = entidad.Importe * 0.18f;
            entidad.Total = entidad.Importe + entidad.Igv;

            var model = new DADetalleEjecuciones();
            var actualizado = model.UpdateDetalleOperacion(entidad);

            if (!actualizado)
            {
                return NotFound(new { mensaje = $"No se encontró o no se pudo actualizar la operación con ID {id}" });
            }

            return Ok(new { mensaje = "Operación actualizada correctamente.", datos = entidad });
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var model = new DADetalleEjecuciones();
            var eliminado = model.DeleteDetalleOperacion(id);

            if (!eliminado)
            {
                return NotFound(new { mensaje = $"No se encontró o no se pudo eliminar la operación con ID {id}" });
            }

            return Ok(new { mensaje = $"Operación con ID {id} eliminada correctamente." });
        }
    }
}
