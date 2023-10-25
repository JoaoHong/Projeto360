
using Projeto360.DAO.Interface.IRepository;
using Projeto360.DAO.Models;

namespace Projeto360.DAO.Repository
{
    public class RepositoryUsuario : Repository<Usuario, TesteDevContext>, IRepositoryUsuario
    {
        public RepositoryUsuario() : base() { }
        public RepositoryUsuario(TesteDevContext context) : base(context) { }
    }
}
