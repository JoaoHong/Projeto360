using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projeto360.DAO.Interface.IService;
using Projeto360.DAO.Models;
using Projeto360.DAO.Models.VM;
using System.Text;

namespace Projeto360.API.Controllers
{
	public class UserController : Controller
	{
		private readonly IServiceUsuario _serviceUsuario;

		private UserController(
			IServiceUsuario serviceUsuario
		)
		{
			_serviceUsuario = serviceUsuario;
		}

		public IActionResult Index()
		{
			return View();
		}

		


	}
}
