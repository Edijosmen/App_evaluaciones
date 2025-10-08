using App_Evaluaciones.Models;
using App_Evaluaciones.Models.Dto;

namespace App_Evaluaciones.Repositories.Interfaces
{
    public interface IEvaluacionRepository
    {
        Task<List<EvaluacionDto>> GetAll_Evaluacion();
        Task<List<Pregunta>> GetAll_Preguntas( int IdEva);
    }
}
