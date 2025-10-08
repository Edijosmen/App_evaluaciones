namespace App_Evaluaciones.Models.Dto
{
    public class EvaluacionCreateDto
    {
        public int EvaluacionId { get; set; }
        public string Nombre { get; set; }
        public DateOnly FInicio { get; set; }
        public DateOnly FCierre { get; set; }
        public string Descripcion { get; set; }
        public List<Pregunta> Pregunta { get; set; } = new List<Pregunta>();
    }
}
