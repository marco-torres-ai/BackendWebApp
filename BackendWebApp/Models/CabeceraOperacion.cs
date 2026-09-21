using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendWebApp.Models
{
    public class CabeceraOperacion
    {

        [Key]
        [Display(Name = "Id")]
        [Required]
        public int IdCabeceraOperacion { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        [MaxLength(100, ErrorMessage = "El campo no debe de tener más de 100 caracteres.")]
        public string Cliente { get; set; }  


        [Display(Name = "Registro")]
        [Required]

        public DateTime Registro { get; set; }

        [JsonIgnore]
        public ICollection<DetalleOperacion> DetalleOperacIons { get; set; } 

    }


}
           
        