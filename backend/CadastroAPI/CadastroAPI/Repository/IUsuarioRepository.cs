using CadastroAPI.Models;

namespace CadastroAPI.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();

        Usuario Get(int id);
        
        int Update(Usuario usuario);

        void Delete(Usuario usuario);
    }
}
