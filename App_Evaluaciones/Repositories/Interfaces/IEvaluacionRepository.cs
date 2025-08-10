using App_Evaluaciones.Models;

namespace App_Evaluaciones.Repositories.Interfaces
{
    public interface IEvaluacionRepository
    {
        Task<List<Evaluacion>> GetAll_Evaluacion();
        Task<List<Pregunta>> GetAll_Preguntas( int IdEva);
    }
}
