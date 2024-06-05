using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Domain.Entities
{
    [Table("UsuariosCompletos")]
    public class UsuarioCompleto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellido { get; set; }
        public int Edad { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Telefono { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
        [MaxLength(50)]
        public string Ciudad { get; set; }
        [MaxLength(50)]
        public string Pais { get; set; }
        [MaxLength(10)]
        public string CodigoPostal { get; set; }
        [MaxLength(10)]
        public string Genero { get; set; }
    }
}
