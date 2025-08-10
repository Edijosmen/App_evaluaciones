using App_Evaluaciones.Models;
using App_Evaluaciones.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App_Evaluaciones.Controllers
{
    public class EvaluacionController : Controller
    {
        private readonly IEvaluacionRepository _evaluacionRepository;
        private readonly IUserRepository _userRepository;
        public EvaluacionController(IEvaluacionRepository evaluacionRepository,IUserRepository userRepository)
        {
            _evaluacionRepository = evaluacionRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index(int IdEva, int IdUser)
        {
            var usuario = await _userRepository.Get_UserXIduser(IdUser);
            var preguntas = await _evaluacionRepository.GetAll_Preguntas(IdEva);
            EvaluacionView evaluacionView = new EvaluacionView();
            Evaluado evaluado = new();
            List<Pregunta> pregunta = new();
            evaluacionView.Evaluado = evaluado;
            evaluacionView.Preguntas = pregunta;
            evaluacionView.Evaluado.Cedula = usuario.Cedula;
            evaluacionView.Evaluado.Parque = usuario.Parque;
            evaluacionView.Evaluado.Proceso = usuario.Proceso;
            evaluacionView.Evaluado.Cargo = usuario.Cargo;
            evaluacionView.Evaluado.Nombre = usuario.Nombre;
            evaluacionView.Preguntas = preguntas;
            return View(evaluacionView);
        }

        public IActionResult ViewEvalucion(int IdEva)
        {
            var preguntas = _evaluacionRepository.GetAll_Preguntas(IdEva);
            return View();
        }
    }
}
