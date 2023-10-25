using System.ComponentModel.DataAnnotations;

namespace Projeto360.DAO.Models.VM
{
    public class ProdutoVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O campo Preço não pode ser negativo.")]
        public decimal? Preco {  get; set; }
    }
}
