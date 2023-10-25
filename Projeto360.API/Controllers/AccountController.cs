using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Projeto360.DAO.Interface.IService;
using Projeto360.DAO.Models;
using Projeto360.DAO.Models.VM;
using System.Text;

namespace Projeto360.API.Controllers
{
	[Route("[controller]")]
	public class AccountController : Controller
	{
        private readonly IServiceUsuario _serviceUsuario;

		public AccountController(
            IServiceUsuario  serviceUsuario
			)
		{
            _serviceUsuario = serviceUsuario;
		}

		[HttpGet("Login")]
		public IActionResult Login()
		{

			return View();
		}

        [HttpPost("Acessar")]
        public IActionResult Acessar([FromBody] UsuarioVM model)
        {
            var usuario = _serviceUsuario.ObterPorSenhaNome(model.Nome, model.Senha);

            if (usuario == null)
            {
                return Json(new
                {
                    ok = false,
                    Title = "Erro",
                    Message = "nome ou senha errado",
                });
            }
            else
            {
                return Json(new
                {
                    ok = true,
                    Title = "Sucesso",
                    Message = "Tudo certo",
                });
            }            
        }

        [HttpGet("CriarLogin")]
        public IActionResult CriarLogin()
        {

            return View();
        }


        [HttpPost("AdicionarUsuario")]
        public IActionResult AdicionarUsuario([FromBody] UsuarioVM model)
        {

            try
            {
                Usuario usuario = new Usuario();

                usuario.Nome = model.Nome;
                usuario.Senha = Convert.ToBase64String(Encoding.ASCII.GetBytes(model.Senha));

                bool sucesso = _serviceUsuario.Adicionar(usuario);

                return Json(new
                {
                    Ok = sucesso,
                    Title = sucesso ? "Sucesso" : "Erro",
                    Message = sucesso ? "Sucesso ao adicionar o usuário!" : "Erro ao adicionar o usuário!",
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Ok = false,
                    Title = "Erro",
                    Message = e.InnerException?.Message ?? e.Message,
                });
            }
        }
    }
}
