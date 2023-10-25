namespace Projeto360.DAO.IService
{
	public interface IService<TEntity>
	{
		TEntity ObterPorId(int id, string includeProperties = "");

		TEntity[] ObterTodos(string includeProperties = "", bool noTracking = true);

		bool Adicionar(TEntity entity);

		bool AdicionarTodos(IEnumerable<TEntity> entities);

		bool Editar(TEntity entity);

		bool EditarTodos(IEnumerable<TEntity> entities);

		bool Deletar(int id);

	}
}
