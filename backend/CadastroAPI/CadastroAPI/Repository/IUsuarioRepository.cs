using CadastroAPI.Entities;

namespace CadastroAPI.Repository
{
    public interface IUsuarioRepository
    {
        Task<int> Create(Usuario usuario);

        Task<IEnumerable<Usuario>> GetAll();

        Task<Usuario> GetById(int id);
        
        Task<bool> Update(int id, Usuario usuario);

        Task<bool> Delete(int id);
    }
}
