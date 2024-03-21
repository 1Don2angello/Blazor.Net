using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Personajes")]
    public class Personajes
    {
        [Key]
        public int PkPersonaje { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public bool Conseguido { get; set; }
        public string Arma { get; set; }
    }
}
