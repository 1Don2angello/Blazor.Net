using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{    [Table("Profesores")]
    public class ProfesorCompleto
    {
        [Key]
        public int pkProfesor { get; set; }
        [MaxLength(10)]
        public string Nombre { get; set; }
        [MaxLength(10)]
        public string ApPaterno { get; set; }
        [MaxLength(10)]
        public string ApMaterno { get; set; }
        [MaxLength(10)]
        public string Matricula { get; set; }
        [MaxLength(10)]
        public DateTime FechaIngreso { get; set; }

    }
}
