using System.ComponentModel.DataAnnotations;

namespace Projeto360.DAO.Models.VM
{
    public class ProdutoVM
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco {  get; set; }
    }
}
