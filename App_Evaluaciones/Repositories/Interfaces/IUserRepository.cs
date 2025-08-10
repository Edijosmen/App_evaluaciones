using App_Evaluaciones.Models;

namespace App_Evaluaciones.Repositories.Interfaces
{
    public interface IUserRepository
    {
       Task<List<Usuario>> GetAll_User();
       Task<Usuario> Validate_User(Usuario Usuario);
       Task<Usuario> Get_User(string cedula);
       Task<List<Evaluado>> Get_Evaluado(string cedula, int idEva);
       Task<Usuario> Get_UserXIduser(int Iduser);
    }
}
