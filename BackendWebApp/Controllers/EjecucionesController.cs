using BackendWebApp.Data.AccesoDatos;
using BackendWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebApp.Controllers
{
    public class EjecucionesController : Controller
    {
        public IActionResult Index()
        {

            var ObjDetalleEjecucion = new Data.AccesoDatos.DADetalleEjecuciones();
            var model = ObjDetalleEjecucion.GetDetalleOperacion();
            return View(model);
        }

        public IActionResult ObjVBEjecuciones()
        {
            var ObjEjecuciones = new DADetalleEjecuciones();
            ViewBag.Ejecuciones = ObjEjecuciones.GetDetalleOperacion();
            return View();
        }

        public IActionResult ObjVDEjecuciones()
        {
            var ObjEjecuciones = new DADetalleEjecuciones();
            ViewData["Ejecuciones"] = ObjEjecuciones.GetDetalleOperacion();
            ViewData["Titulo"] = "Listado de Ejecuciones - ViewData";
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new DACabeceraEjecuciones();
            ViewBag.CabEjecuciones = model.GetCabeceraOperacion();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DetalleOperacion Entidad)
        {
            Entidad.IdDetalleOperacion = 0;
            Entidad.Igv = (Entidad.Importe * 0.18f);
            Entidad.Total = Entidad.Importe + Entidad.Igv;

            var DAOperacion = new DADetalleEjecuciones();
            var resultado = DAOperacion.InsertDetalleOperacion(Entidad);

            if (resultado > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var modelCab = new DACabeceraEjecuciones();
                ViewBag.CabEjecuciones = modelCab.GetCabeceraOperacion();
                return View(Entidad);
            }
        }
    }
}
