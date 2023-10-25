using Projeto360.DAO.Models;

namespace Projeto360.DAO.Interface.IService
{
	public interface IServiceUsuario
	{
		Usuario ObterPorIdUsuarios(int UsuariosId);

		bool Adicionar(Usuario entity);

		bool Editar(Usuario entity);

		bool Deletar(int id);

		IEnumerable<Usuario> Listar();

		Usuario ObterPorSenhaNome(string Nome, string Senha);
	}
}
