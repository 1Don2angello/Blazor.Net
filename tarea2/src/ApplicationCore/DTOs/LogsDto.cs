namespace ApplicationCore.DTOs
{
    public class LogsDto
    {
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; }
        public string IpAddress { get; set; }
        public string NomFuncion { get; set; }
        public string StatusLog { get; set; }
        public string Datos { get; set; }
    }
}
