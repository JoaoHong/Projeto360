using Projeto360.DAO.Models;
using Projeto360.DAO.Interface.IRepository;
using Projeto360.DAO.Interface.IService;
using System.Text;

namespace VascoVasconcellos.DAO.Service
{
	public class ServiceUsuario : IServiceUsuario
	{
		private readonly IRepositoryUsuario _repositoryUsuarios;

		public ServiceUsuario(IRepositoryUsuario repositoryUsuarios)
		{
			_repositoryUsuarios = repositoryUsuarios;
		}

		public Usuario ObterPorIdUsuarios(int id)
		{
			return _repositoryUsuarios.FirstOrDefault(x => x.Id == id);
		}

        public Usuario ObterPorSenhaNome(string Nome, string Senha)
        {
            return _repositoryUsuarios.FirstOrDefault(x => x.Nome == Nome && x.Senha == Convert.ToBase64String(Encoding.ASCII.GetBytes(Senha)));
        }

        public bool Adicionar(Usuario entity)
		{
			return _repositoryUsuarios.Insert(entity);
		}

		public bool Editar(Usuario entity)
		{
			return _repositoryUsuarios.Update(entity);
		}

		public bool Deletar(int id)
		{
			return _repositoryUsuarios.Delete(id);
		}

		public IEnumerable<Usuario> Listar()
		{
			return _repositoryUsuarios.Get();
		}

	}
}
