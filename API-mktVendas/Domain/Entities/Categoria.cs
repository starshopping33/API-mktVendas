using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    // Relacionamento
    public ICollection<Produto>? Produtos { get; set; }
}
