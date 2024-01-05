using System.Data;
using CadastroAPI.Entities;
using Dapper;

namespace CadastroAPI.Repository
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly IDbConnection _dbConnection;

        public HistoricoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> Create(HistoricoEscolar historico)
        {
            var parameters = new {
                historico.Formato,
                historico.Nome
            };

            const string sql = @"
                INSERT INTO HistoricoEscolar OUTPUT INSERTED.IdHistoricoEscolar
                VALUES (@Formato, @Nome)";

            int id = await _dbConnection.ExecuteScalarAsync<int>(sql, parameters);

            return id;
        }

        public async Task<int> CreateRelationship(int idUsuario, int idHistorico)
        {
            var parameters = new {
                iduser = idUsuario,
                id = idHistorico
            };

            const string sql = @"
                INSERT INTO UsuarioHistoricoEscolar OUTPUT INSERTED.IdUsuarioHistoricoEscolar
                VALUES (@iduser, @id)";

            var result = await _dbConnection.ExecuteScalarAsync<int>(sql, parameters);
            

            return result;
        }

        public async Task<HistoricoEscolar> GetById(int idHistorico)
        {
            var parameters = new {
                idHistorico
            };

            const string sql = @"
                SELECT 
                    IdHistoricoEscolar,
                    Formato,
                    Nome
                FROM HistoricoEscolar
                WHERE IdHistoricoEscolar = @idHistorico";

            var historico = await _dbConnection.QueryFirstOrDefaultAsync<HistoricoEscolar>(sql, parameters);

            return historico;
        }

        public async Task<int> Delete(int idHistorico)
        {
            var parameters = new {
                idHistorico
            };

            const string sql = @"
                DELETE HistoricoEscolar
                WHERE IdHistoricoEscolar = @idHistorico";

            int id = await _dbConnection.ExecuteAsync(sql, parameters);

            return id;
        }

        public async Task<int> DeleteRelationship(int idHistorico)
        {
            var parameters = new {
                idHistorico
            };

            const string sql = @"
                DELETE UsuarioHistoricoEscolar
                WHERE IdHistoricoEscolar = @idHistorico";

            int id = await _dbConnection.ExecuteAsync(sql, parameters);

            return id;
        }
    }
}