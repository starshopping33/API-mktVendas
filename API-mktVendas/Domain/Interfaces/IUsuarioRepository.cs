using projeto_vwndas.Projeto_Vendas_API.Domain.Entities;



namespace API_mktVendas.Domain.Interfaces;
    public interface IUsusarioRepository { 

    Task<Usuario?> GetByEmailAsync(string email);
    Task<Usuario?> GetByIdAsync(int id);
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);

    Task DeleteAsync(Usuario usuario);
    Task SaveChangesAsync();

}
