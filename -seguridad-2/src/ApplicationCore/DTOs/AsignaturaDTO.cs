using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class AsignaturaDTO
    {
        public int pkAsignatura { get; set; }
       public string Asignatura { get; set; }
        public int fkProfesor {  get; set; }
    }
}
