using CadastroAPI.Entities;

namespace CadastroAPI.Repository
{
    public interface IHistoricoRepository
    {
        Task<int> Create(HistoricoEscolar historicoEscolar);
        
        Task<int> CreateRelationship(int idUsuario, int idHistorico);

        Task<HistoricoEscolar> GetById(int id);

        Task<int> Delete(int idHistorico);

        Task<int> DeleteRelationship(int idHistorico);

    }
}