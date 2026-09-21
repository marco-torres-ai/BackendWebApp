using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendWebApp.Models
{
    public class DetalleOperacion

    {
        [Key]
        [Display(Name = "Id")]
        [Required]
        public int IdDetalleOperacion { get; set; }



        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar la descripción de la operación.")]
        [MaxLength(100, ErrorMessage = "El campo no debe de tener más de 100 caracteres.")]
        public string Descripcion { get; set; }



        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe ingresar la cantidad de la operación.")]
        public int Cantidad { get; set; }
        

        [Display(Name = "Importe")]
        [Required(ErrorMessage = "Debe ingresar el importe de la operación.")]
        public float Importe { get; set; }
        [Display(Name = "IGV")]
        [Required]
        public float Igv { get; set; }

        [Display(Name = "Total")]
        [Required]
        public float Total { get; set; }

        public int IdCabeceraOperacion { get; set; }

        
        [ForeignKey("IdCabeceraOperacion")]
        public virtual CabeceraOperacion? CabeceraOperacion { get; set; }



    }



}
