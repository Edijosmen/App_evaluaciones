using App_Evaluaciones.Models.Dto;

namespace App_Evaluaciones.Models
{
    public class Usuario
    {
        public int UserId { get; set; }
        public string Proceso { get; set; }
        public string Parque { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Grupo { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public List<EvaluacionDto> Evalaciones { get; set; }
    }
}
