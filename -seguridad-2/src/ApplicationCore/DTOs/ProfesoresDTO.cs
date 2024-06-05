using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class ProfesoresDTO
    {

        public int pkProfesor { get; set; }
        public string Nombre { get; set; }
        public string ApMaterno { get; set; }
        public string ApPaterno { get; set; }
        public string Matricula { get; set; }
        public DateTime FechaIngreso { get; set; }
        = DateTime.Now;
    }
}
