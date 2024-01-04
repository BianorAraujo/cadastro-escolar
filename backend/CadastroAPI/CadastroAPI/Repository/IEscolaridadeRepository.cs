using CadastroAPI.Entities;

namespace CadastroAPI.Repository
{
    public interface IEscolaridadeRepository
    {
        Task<IEnumerable<NivelEscolar>> GetAll();
    }
}