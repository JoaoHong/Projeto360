
using Projeto360.DAO.Interface.IRepository;
using Projeto360.DAO.Models;

namespace Projeto360.DAO.Repository
{
	public class RepositoryProduto : Repository<Produto, TesteDevContext>, IRepositoryProduto
	{
		public RepositoryProduto() : base() { }
		public RepositoryProduto(TesteDevContext context) : base(context) { }
	}
}
