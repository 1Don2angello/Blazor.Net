using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs.Personaje
{
    public class PersonajeDto
    {
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public bool Conseguido { get; set; }
        public string Arma { get; set; }
    }

}
