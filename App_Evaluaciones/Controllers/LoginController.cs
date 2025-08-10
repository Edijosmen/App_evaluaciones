using App_Evaluaciones.Models;
using App_Evaluaciones.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace App_Evaluaciones.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRespository;
        public LoginController(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario usuario)
        {
           Usuario rs_usuario = await _userRespository.Validate_User(usuario);
            if (rs_usuario == null)
            {
                ModelState.AddModelError(string.Empty, "El usuario ingresado no esta registrado!");
                return View(usuario);
                // Devolver la vista con los datos actuales
            }
            if(rs_usuario.Cedula==usuario.Cedula && rs_usuario.Password== usuario.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , rs_usuario.Nombre),
                    new Claim("Proceso", rs_usuario.Proceso),
                    new Claim(ClaimTypes.Role,rs_usuario.Rol),
                    new Claim("Cedula",rs_usuario.Cedula)
                };

                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrecta!");
               
            }
            return View(usuario);
        }

        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
