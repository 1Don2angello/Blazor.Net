using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Logs")]
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Nombre_funcion { get; set; }
        public string Respuesta { get; set; }
        public string Datos { get; set; }
    }
}
