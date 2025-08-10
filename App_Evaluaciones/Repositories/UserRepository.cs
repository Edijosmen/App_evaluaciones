using App_Evaluaciones.DbConection;
using App_Evaluaciones.Models;
using App_Evaluaciones.Repositories.Interfaces;
using MySqlConnector;

namespace App_Evaluaciones.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MysqlContext _dbContext;
        public UserRepository(MysqlContext db)
        {
            _dbContext = db;
        }
        public async Task<List<Usuario>> GetAll_User()
        {
            List<Usuario> list_usuarios = new List<Usuario>();
            using var connection = _dbContext.GetConnection();
            string sql = "SELECT * FROM usuario";
            MySqlCommand Command = new MySqlCommand(sql, connection);
            MySqlDataReader rs = Command.ExecuteReader();
            while (rs.Read())
            {
                Usuario rs_usuario = new Usuario
                {
                    Proceso = rs.GetString("proceso"),
                    Parque = rs.GetString("parque"),
                    Cedula = rs.GetString("cedula"),
                    Nombre = rs.GetString("nombre"),
                    Cargo = rs.GetString("cargo"),
                    Grupo = rs.GetString("grupo")
                };

                list_usuarios.Add(rs_usuario);
            }
            connection.Close();
            return list_usuarios;
        }

        public async Task<List<Evaluado>> Get_Evaluado(string cedula, int idEva)
        {
            List<Evaluado> list_usuarios = new List<Evaluado>();
            using var connection = _dbContext.GetConnection();
            string sql = @"SELECT 
                            evaluado.iduser,
                            evaluado.proceso,
                            evaluado.parque,
                            evaluado.cedula,
                            evaluado.nombre,
                            evaluado.cargo,
                            evaluado.grupo
                        FROM asignaciones AS asg
                        JOIN usuario AS evaluador ON asg.EvaluadorId = evaluador.idUser
                        JOIN usuario AS evaluado ON asg.EvaluadoId = evaluado.idUser
                        WHERE evaluador.cedula = @cedula AND asg.EvaluacionId =@idEva";
            MySqlCommand Command = new MySqlCommand(sql, connection);
            Command.Parameters.AddWithValue("@cedula", cedula);
            Command.Parameters.AddWithValue("@idEva", idEva);
            MySqlDataReader rs = Command.ExecuteReader();

            while (rs.Read())
            {
                Evaluado rs_usuario = new Evaluado
                {
                    UserId = rs.GetInt32("iduser"),
                    Proceso = rs.GetString("proceso"),
                    Parque = rs.GetString("parque"),
                    Cedula = rs.GetString("cedula"),
                    Nombre = rs.GetString("nombre"),
                    Cargo = rs.GetString("cargo"),
                    Grupo = rs.GetString("grupo")
                };

                list_usuarios.Add(rs_usuario);
            }
            connection.Close();
            return list_usuarios;
        }

        public async Task<Usuario> Get_User(string cedula)
        {
            using var connection = _dbContext.GetConnection();
            string sql = "SELECT * FROM usuario WHERE cedula=@cedula";
            MySqlCommand Command = new MySqlCommand(sql, connection);
            Command.Parameters.AddWithValue("@cedula", cedula);
            MySqlDataReader rs = Command.ExecuteReader();
            if (rs.Read())
            {
                Usuario rs_usuario = new Usuario
                {
                    UserId = rs.GetInt32("iduser"),
                    Nombre = rs.GetString("nombre"),
                    Proceso = rs.GetString("proceso"),
                    Cedula = rs.GetString("cedula"),
                    Parque = rs.GetString("parque"),
                    Cargo = rs.GetString("cargo"),
                    Grupo = rs.GetString("grupo")
                };

                return rs_usuario;
            }
            else
            {
                return null;
            }
        }

        public async Task<Usuario> Validate_User(Usuario Usuario)
        {

            using var connection = _dbContext.GetConnection();
            string sql = "SELECT * FROM usuario WHERE cedula=@cedula";
            MySqlCommand Command = new MySqlCommand(sql, connection);
            Command.Parameters.AddWithValue("@cedula",Usuario.Cedula);
            MySqlDataReader rs = Command.ExecuteReader();
            if (rs.Read())
            {
                Usuario rs_usuario = new Usuario
                {
                    Nombre = rs.GetString("nombre"),
                    Rol = rs.GetString("rol"),
                    Proceso = rs.GetString("proceso"),
                    Cedula = rs.GetString("cedula"),
                    Password = rs.GetString("password")
                };

                return rs_usuario;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<Usuario> Get_UserXIduser(int Iduser)
        {
            using var connection = _dbContext.GetConnection();
            string sql = "SELECT * FROM usuario WHERE iduser=@Iduser";
            MySqlCommand Command = new MySqlCommand(sql, connection);
            Command.Parameters.AddWithValue("@iduser", Iduser);
            MySqlDataReader rs = Command.ExecuteReader();
            if (rs.Read())
            {
                Usuario rs_usuario = new Usuario
                {
                    UserId = rs.GetInt32("iduser"),
                    Nombre = rs.GetString("nombre"),
                    Proceso = rs.GetString("proceso"),
                    Cedula = rs.GetString("cedula"),
                    Parque = rs.GetString("parque"),
                    Cargo = rs.GetString("cargo"),
                    Grupo = rs.GetString("grupo")
                };

                return rs_usuario;
            }
            else
            {
                return null;
            }
        }
    }
}
