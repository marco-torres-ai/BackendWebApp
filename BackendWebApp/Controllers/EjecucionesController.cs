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

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var da = new DADetalleEjecuciones();
            var entidad = da.GetDetalleOperacionById(id.Value);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var da = new DADetalleEjecuciones();
            var entidad = da.GetDetalleOperacionById(id.Value);
            if (entidad == null)
            {
                return NotFound();
            }

            var modelCab = new DACabeceraEjecuciones();
            ViewBag.CabEjecuciones = modelCab.GetCabeceraOperacion();
            return View(entidad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DetalleOperacion entidad)
        {
            if (id != entidad.IdDetalleOperacion)
            {
                return NotFound();
            }

            entidad.Igv = entidad.Importe * 0.18f;
            entidad.Total = entidad.Importe + entidad.Igv;

            var da = new DADetalleEjecuciones();
            var actualizado = da.UpdateDetalleOperacion(entidad);

            if (actualizado)
            {
                return RedirectToAction(nameof(Index));
            }

            var modelCab = new DACabeceraEjecuciones();
            ViewBag.CabEjecuciones = modelCab.GetCabeceraOperacion();
            return View(entidad);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var da = new DADetalleEjecuciones();
            var entidad = da.GetDetalleOperacionById(id.Value);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var da = new DADetalleEjecuciones();
            da.DeleteDetalleOperacion(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
