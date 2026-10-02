using BackendWebApp.Data.AccesoDatos;
using BackendWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebApp.Controllers
{
    [ApiController]
    [Route("api/cabeceras")]
    [AllowAnonymous]
    [EnableCors("AngularPolicy")]
    public class CabecerasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            var model = new DACabeceraEjecuciones();
            var datos = model.GetCabeceraOperacion();

            return Ok(datos);
        }
    }
}
