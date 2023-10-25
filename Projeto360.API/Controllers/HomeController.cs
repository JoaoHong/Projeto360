using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Projeto360.DAO.IService;
using Projeto360.DAO.Interface.IService;
using Projeto360.DAO.Models.VM;
using Projeto360.DAO.Models;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using System.Text;
using VascoVasconcellos.DAO.Service;

namespace Projeto360.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IServiceProduto _serviceProduto;
        private readonly IServiceUsuario _serviceUsuario;

		public HomeController
		(
			ILogger<HomeController> logger,
			IServiceProduto serviceProduto,
            IServiceUsuario serviceUsuario
		)
		{
			_logger = logger;
			_serviceProduto = serviceProduto;
            _serviceUsuario = serviceUsuario;
		}

		public IActionResult Index()
		{

            var listaProdutos = _serviceProduto.Listar().ToList();

            return View(listaProdutos);

        }

   
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account");
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
				if(ModelState.IsValid)
				{
                    Produto produto = new Produto
                    {
                        Preco = (decimal)model.Preco,
                        DataCriacao = brasilNow,
                        Nome = model.Nome,
                        Descricao = model.Descricao,
                    };

                    sucesso = _serviceProduto.Adicionar(produto);

                    return Json(new
                    {
                        Ok = sucesso,
                        Title = sucesso ? "Sucesso" : "Erro",
                        Message = sucesso ? "Sucesso ao adicionar produto!" : "Erro ao adicionar produto, tente novamente. Caso o erro persista falar com om administrador do site."
                    });
				}
				else
				{
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();
					string textoErro = string.Join("<br>", errors);

                    return Json(new
                    {
                        Ok = false,
                        Title = "Erro",
                        Message = "Erro ao adicionar produto. Corrija os seguintes erros:<br>" + textoErro,
                        Errors = errors
                    });
                }
				

				
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

        public IActionResult DeletarProduto(int Id)
        {

            bool sucesso = false;

            try
            {

                sucesso = _serviceProduto.Deletar(Id);


                return Json(new
                {
                    Ok = sucesso,
                    Title = sucesso ? "Sucesso" : "Erro",
                    Message = sucesso ? "Sucesso ao deletar produto!" : "Erro ao deletar produto, tente novamente. Caso o erro persista falar com om administrador do site."
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

        public IActionResult Visualizar(int Id)
        {
            var produto = _serviceProduto.ObterPorIdProdutos(Id);

            return View(produto);
        }


        public IActionResult Editar(int Id)
        {
            var produto = _serviceProduto.ObterPorIdProdutos(Id);

            return View(produto);
        }


        public async Task<IActionResult> EditarProduto([FromBody] ProdutoVM model)
        {

            bool sucesso = false;

            try
            {
                if (ModelState.IsValid)
                {
                    Produto produto = _serviceProduto.ObterPorIdProdutos((int)model.Id);

                    produto.Preco = (decimal)model.Preco;
                    produto.Descricao = model.Descricao;
                    produto.Nome = model.Nome;

                    sucesso = _serviceProduto.Editar(produto);

                    return Json(new
                    {
                        Ok = sucesso,
                        Title = sucesso ? "Sucesso" : "Erro",
                        Message = sucesso ? "Sucesso ao editar produto!" : "Erro ao editar produto, tente novamente. Caso o erro persista falar com om administrador do site."
                    });
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                    .Select(e => e.ErrorMessage)
                                    .ToList();
                    string textoErro = string.Join("<br>", errors);

                    return Json(new
                    {
                        Ok = false,
                        Title = "Erro",
                        Message = "Erro ao editar produto. Corrija os seguintes erros:<br>" + textoErro,
                        Errors = errors
                    });
                }



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


    }
}