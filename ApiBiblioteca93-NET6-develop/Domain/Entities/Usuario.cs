using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Usuario // Objeto Usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        [ForeignKey("Roles")]
        public int? FKRol { get; set; }

        public Rol Roles { get; set; }



    }
}
