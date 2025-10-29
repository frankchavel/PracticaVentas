using System.ComponentModel.DataAnnotations;

namespace AppVentas.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage ="El campo nombre es obligatorio.")]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        public string Apellido { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "El campo email es obligatorio.")]
        public string Email { get; set; }
        [StringLength(15)]
        [Required(ErrorMessage = "El campo teléfono es obligatorio.")]
        public string Telefono { get; set; }
    }
}
