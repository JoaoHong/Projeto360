using Projeto360.DAO.Models;

namespace Projeto360.DAO.Interface.IService
{
	public interface IServiceProduto
	{
		Produto ObterPorIdProdutos(int ProdutosId);

		bool Adicionar(Produto entity);

		bool Editar(Produto entity);

		bool Deletar(int id);

		IEnumerable<Produto> Listar();

	}
}
