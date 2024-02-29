using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido_com { get; set; }
        public int? Edad { get; set; }
        public string? Ciudad { get; set; }
        public bool? Estatus { get; set; }

    }
}
