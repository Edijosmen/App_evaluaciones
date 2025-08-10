using App_Evaluaciones.Models;
using App_Evaluaciones.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace App_Evaluaciones.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRespository;
        private readonly IEvaluacionRepository _evalacionRespository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRespository, IEvaluacionRepository evalacionRespository)
        {
            _logger = logger;
            _userRespository = userRespository;
            _evalacionRespository = evalacionRespository;
        }

        public async Task<IActionResult> Index()
        {
            //_userRespository.GetAll_User();
            var evaluaciones = await _evalacionRespository.GetAll_Evaluacion();
            //var evaluados = await _userRespository.Get_Evaluado("1124862267",3);
            //Extraemos la Cedula registrada en los Claims cuando se logio
            string? cedula = User.FindFirst("Cedula")?.Value;
            if (evaluaciones.Any())
            {
                foreach (var item in evaluaciones)
                {
                    //Extraemos los usuarios a evaluar por cada evaluacion que tengamos asignadas
                    item.Evaluados = await _userRespository.Get_Evaluado(cedula, item.EvaluacionId);
                }
            }
            if (cedula != null)
            {
                Usuario usuario = await _userRespository.Get_User(cedula);
                usuario.Evalaciones = evaluaciones;
                return View(usuario);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}