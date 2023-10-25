using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto360.DAO.Models;
using Projeto360.DAO.Models.VM;
using System.Text;

namespace Projeto360.API.Controllers
{
	public class UserController : Controller
	{
		private UserManager<AspNetUser> _userManager;

		private UserController(
			UserManager<AspNetUser> userManager
		)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost("AdicionarUsuario")]
		public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioVM model)
		{
			AspNetUser userLogado = await _userManager.FindByNameAsync(User.Identity.Name);
			

			try
			{

				var user = new AspNetUser
				{
					FirstName = model.PrimeiroNome,
					LastName = model.UltimoNome,
					UserName = model.Nome,
					TwoFactorEnabled = false, //Ativa a verificação em 2 etapas para o usuário
				};


				var chkUser = await _userManager.CreateAsync(user, model.Senha);

				bool sucesso = chkUser.Succeeded;

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
