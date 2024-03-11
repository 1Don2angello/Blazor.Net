using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApplicationCore.DTOs

{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellido_com { get; set; }
        public int Edad { get; set; }
        public string Ciudad { get; set; }
        public bool Estatus { get; set; }
    }
}
