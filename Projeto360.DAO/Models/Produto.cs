using System;
using System.Collections.Generic;

namespace Projeto360.DAO.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DataCriacao { get; set; }
}
