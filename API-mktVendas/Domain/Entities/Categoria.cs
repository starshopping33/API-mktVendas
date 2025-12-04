using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


public class Categoria
{
    [Key]
    public int CategId { get; set; } // Ou CategoriaId, dependendo da sua convenção de PK
    public string Nome { get; set; }

    // Propriedade de Navegação: Uma Categoria pode ter vários Produtos
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}