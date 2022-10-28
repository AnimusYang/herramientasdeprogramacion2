using System.ComponentModel.DataAnnotations;

namespace api_autores.Entitys
{
    public class Libro
    {
        [Key]
        public int codigolibro { get; set; }
        [Required]
        //definimos el tamaño del campo
        [StringLength(
         maximumLength: 100,
         ErrorMessage = "Se tiene que ingresar  un Nombre")]
        public string titulo { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public Autor autor { get; set; }

    }
}
