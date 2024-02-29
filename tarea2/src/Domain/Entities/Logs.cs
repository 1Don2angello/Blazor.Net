using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Logs")]
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public string IpAddress { get; set; }
        public string NomFuncion { get; set; }
        public string StatusLog { get; set; }
        public string Datos { get; set; }

    }
}
