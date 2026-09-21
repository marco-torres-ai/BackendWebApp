using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendWebApp.Data
{
    
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext()
        {
        }

        // Constructor que pasa las opciones correctamente a la clase base
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets organizados y corregidos
        public virtual DbSet<BackendWebApp.Models.CabeceraOperacion> CabeceraOperacion { get; set; }
        public virtual DbSet<BackendWebApp.Models.DetalleOperacion> DetalleOperacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Conexión configurada con el usuario 'sa' y tu contraseña '123'
                optionsBuilder.UseSqlServer(
                    "Server=MARQUITO\\SQLEXPRESS01;Database=DBEjecucion_IDS_26_II;User Id=sa;Password=123;TrustServerCertificate=True;MultipleActiveResultSets=true"
                );
            }
        }
    }
}