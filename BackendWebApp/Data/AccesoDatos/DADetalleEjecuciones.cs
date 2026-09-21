using BackendWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendWebApp.Data.AccesoDatos
{
    public class DADetalleEjecuciones
    {

        public IEnumerable<DetalleOperacion> GetDetalleOperacion()
        {
            // Implementación del método

            var DetOperacion = new List<DetalleOperacion>();
            using (var db=new ApplicationDbContext())
            {
                DetOperacion = db.DetalleOperacion.Include(item => item.CabeceraOperacion).ToList();
            }
            return DetOperacion;
        }

        public int  InsertDetalleOperacion(DetalleOperacion entidad) {
           var resultado = 0;
            using (var db=new ApplicationDbContext())
            {
                db.Add(entidad); // seleccionamos la fila del registro que queremos insertar
                db.SaveChanges(); // guarda en la bd
                resultado = entidad.IdDetalleOperacion;
            }
            return resultado;
        }

        public DetalleOperacion? GetDetalleOperacionById(int id)
        {
            DetalleOperacion? item = null;
            using (var db = new ApplicationDbContext())
            {
                item = db.DetalleOperacion
                    .Include(x => x.CabeceraOperacion)
                    .FirstOrDefault(x => x.IdDetalleOperacion == id);
            }
            return item;
        }

        public bool UpdateDetalleOperacion(DetalleOperacion entidad)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var existente = db.DetalleOperacion.Find(entidad.IdDetalleOperacion);
                if (existente != null)
                {
                    existente.Descripcion = entidad.Descripcion;
                    existente.Cantidad = entidad.Cantidad;
                    existente.Importe = entidad.Importe;
                    existente.Igv = entidad.Igv;
                    existente.Total = entidad.Total;
                    existente.IdCabeceraOperacion = entidad.IdCabeceraOperacion;

                    resultado = db.SaveChanges() > 0;
                }
            }
            return resultado;
        }

        public bool DeleteDetalleOperacion(int id)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                var registro = db.DetalleOperacion.Find(id);
                if (registro != null)
                {
                    db.DetalleOperacion.Remove(registro);
                    resultado = db.SaveChanges() > 0;
                }
            }
            return resultado;
        }
    }
}
