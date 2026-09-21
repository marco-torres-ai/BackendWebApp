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
    }
}
