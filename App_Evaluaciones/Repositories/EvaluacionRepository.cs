using App_Evaluaciones.DbConection;
using App_Evaluaciones.Models;
using App_Evaluaciones.Models.Dto;
using App_Evaluaciones.Repositories.Interfaces;
using MySqlConnector;

namespace App_Evaluaciones.Repositories
{
    public class EvaluacionRepository : IEvaluacionRepository
    {
        private readonly MysqlContext _dbContext;
        public EvaluacionRepository(MysqlContext db)
        {
            _dbContext = db;
        }

        public async Task<List<EvaluacionDto>> GetAll_Evaluacion()
        {
            List<EvaluacionDto> list_evaluacion = new List<EvaluacionDto>();
            using var connection = _dbContext.GetConnection();
            string sql = "SELECT * FROM evaluacion";
            MySqlCommand Command = new MySqlCommand(sql, connection);
            MySqlDataReader rs = Command.ExecuteReader();
            while (rs.Read())
            {
                EvaluacionDto rs_evaluacion = new EvaluacionDto
                {
                    EvaluacionId = rs.GetInt16("evaluacionId"),
                    Descripcion= rs.GetString("descripcion"),
                    Nombre = rs.GetString("nombre"),
                    FInicio = DateOnly.FromDateTime(rs.GetDateTime("finicio")),
                    FCierre = DateOnly.FromDateTime(rs.GetDateTime("fcierre"))
                };

                list_evaluacion.Add(rs_evaluacion);
            }
            connection.Close();
            return list_evaluacion;
        }

        public async Task<List<Pregunta>> GetAll_Preguntas(int IdEva)
        {
            List<Pregunta> list_pregunta = new List<Pregunta>();
            using var connection = _dbContext.GetConnection();
            string sql = "SELECT * FROM preguntas where evaluacionId=@IdEva";
            MySqlCommand Command = new MySqlCommand(sql, connection);
            Command.Parameters.AddWithValue("@IdEva", IdEva);
            MySqlDataReader rs = Command.ExecuteReader();
            while (rs.Read())
            {
                Pregunta rs_pregunta = new Pregunta
                {
                    PreguntaId = rs.GetInt16("preguntaId"),
                    PreguntaName = rs.GetString("npregunta"),
                    EvaluacionId = rs.GetInt16("evaluacionId")  
                };

                list_pregunta.Add(rs_pregunta);
            }
            connection.Close();
            return list_pregunta;
        }
    }
}
