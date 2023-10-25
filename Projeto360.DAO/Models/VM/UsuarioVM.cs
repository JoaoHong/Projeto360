using System.ComponentModel.DataAnnotations;

namespace Projeto360.DAO.Models.VM
{
	public class UsuarioVM
	{

		[Required(ErrorMessage = "O campo {0} é obrigatório!")]
		[DataType(DataType.Password)]
		[Display(Name = "Nova senha")]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#!?%\-\=\\\/\[\]\{\}\(\)])[0-9a-zA-Z$*&@#!?%\-\=\\\/\[\]\{\}\(\)]{8,16}$", ErrorMessage = "A senha deve ter:<br /> <li>Entre 8 e 16 caracteres</li> <li>Pelo menos 1 letra maiúscula e minúscula</li> <li>Pelo menos 1 número e 1 símbolo</li>")]
		public string Senha { get; set; }

		public string Nome { get; set; }

		public string PrimeiroNome { get; set; }

		public string UltimoNome { get; set; }

	}
}
