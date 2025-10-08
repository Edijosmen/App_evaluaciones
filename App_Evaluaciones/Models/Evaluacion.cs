namespace App_Evaluaciones.Models
{
    public class Evaluacion
    {
        public int EvaluacionId { get; set; }
        public string Nombre { get; set; }
        public DateOnly FInicio { get; set; }
        public DateOnly FCierre { get; set; }
        public string Descripcion { get; set; }
    }
}
