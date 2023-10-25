using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Projeto360.DAO.IService;
using Projeto360.DAO.Interface.IService;
using Projeto360.DAO.Models.VM;
using Projeto360.DAO.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IServiceProduto _serviceProduto;

		public HomeController
		(
			ILogger<HomeController> logger,
			IServiceProduto serviceProduto
		)
		{
			_logger = logger;
			_serviceProduto = serviceProduto;
		}

		public IActionResult Index()
		{
			var listaProdutos = _serviceProduto.Listar().ToList();

			return View(listaProdutos);
		}

        public IActionResult Adicionar()
        {
            return View();
        }

		public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoVM model)
		{

			TimeZoneInfo brasilTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
			DateTimeOffset brasilDateTime = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, brasilTimeZone);
            DateTime brasilNow = brasilDateTime.DateTime;

			bool sucesso = false;

			try
			{
				Produto produto = new Produto
				{
					Preco = model.Preco,
					DataCriacao = brasilNow,
					Nome = model.Nome,
					Descricao = model.Descricao,
				};

				sucesso = _serviceProduto.Adicionar(produto );

				return Json(new
				{
					Ok = sucesso,
					Title = sucesso ? "Sucesso" : "Erro",
					Message = sucesso ? "Sucesso ao adicionar produto!" : "Erro ao adicionar produto, tente novamente. Caso o erro persista falar com om administrador do site."
				});
			}
            catch (Exception ex)
            {
                return Json(new
                {
                    Ok = false,
                    Title = "Erro",
                    Message = "Erro ao adicionar produto, relatar erro ao administrador do site! " + ex.Message,
                });
            }
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