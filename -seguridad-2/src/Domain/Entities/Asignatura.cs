using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table ("Asignaturas")]
    public class AsignaturaCompleta
    {
        [Key]
        public int pkAsignatura { get; set; }
        [MaxLength(50)]
        public string Asignatura { get; set; }
        
        public int fkProfesor { get; set; }
    }
}
