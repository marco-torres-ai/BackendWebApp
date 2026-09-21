using BackendWebApp.Data.AccesoDatos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebApp.Controllers
{
    [ApiController] // Esto debe ir a nivel de clase
    [Route("api/[controller]")] // Quitar el espacio extra
    [AllowAnonymous]
    [EnableCors("AngularPolicy")]
    public class BackEjecucionesController : ControllerBase // Usar ControllerBase para API
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
    }
}
