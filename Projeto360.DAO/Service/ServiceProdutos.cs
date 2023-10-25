using Projeto360.DAO.Models;
using Projeto360.DAO.Interface.IRepository;
using Projeto360.DAO.Interface.IService;

namespace VascoVasconcellos.DAO.Service
{
	public class ServiceProduto : IServiceProduto
	{
		private readonly IRepositoryProduto _repositoryProdutos;

		public ServiceProduto(IRepositoryProduto repositoryProdutos)
		{
			_repositoryProdutos = repositoryProdutos;
		}

		public Produto ObterPorIdProdutos(int id)
		{
			return _repositoryProdutos.FirstOrDefault(x => x.Id == id);
		}

		public bool Adicionar(Produto entity)
		{
			return _repositoryProdutos.Insert(entity);
		}

		public bool Editar(Produto entity)
		{
			return _repositoryProdutos.Update(entity);
		}

		public bool Deletar(int id)
		{
			return _repositoryProdutos.Delete(id);
		}

		public IEnumerable<Produto> Listar()
		{
			return _repositoryProdutos.Get();
		}

	}
}
