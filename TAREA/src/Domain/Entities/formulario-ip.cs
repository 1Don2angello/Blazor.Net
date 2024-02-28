using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities
{
    [Table ("formulario-ip")]
    public class formulario_ip
    {
        [Key]
        public int id { get; set; }
        public string ipp { get; set; }
        public string funcion {  get; set; }
        public string respuesta { get; set; }
        public string datos { get; set; }
    }
}
