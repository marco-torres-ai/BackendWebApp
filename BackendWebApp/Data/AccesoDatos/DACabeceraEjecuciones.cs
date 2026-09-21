using BackendWebApp.Models;

namespace BackendWebApp.Data.AccesoDatos
{
    public class DACabeceraEjecuciones
    {
        public IEnumerable<CabeceraOperacion> GetCabeceraOperacion()
        {
            var listado = new List<CabeceraOperacion>();
            using (var db = new ApplicationDbContext())
            {
                 listado = db.CabeceraOperacion.ToList();
                
            }
            return listado;
        } 
    }
}
