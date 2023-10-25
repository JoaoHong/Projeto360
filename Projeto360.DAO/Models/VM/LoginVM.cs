using System.ComponentModel.DataAnnotations;

namespace Projeto360.DAO.Models.VM
{
	public class LoginVM
	{
		[Required(ErrorMessage = "O campo é obrigatório!")]
		public string Nome { get; set; }

		[Display(Name = "Senha")]
		[Required(ErrorMessage = "O campo é obrigatório!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
