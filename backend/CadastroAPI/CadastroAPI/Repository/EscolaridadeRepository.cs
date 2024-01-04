using CadastroAPI.Entities;
using Dapper;
using System.Data;

namespace CadastroAPI.Repository
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EscolaridadeRepository(IDbConnection dbConnection) 
        {
            _dbConnection = dbConnection;
     
        }

        public async Task<IEnumerable<NivelEscolar>> GetAll()
        {
            const string sql = @"SELECT * FROM Escolaridade";

            var escolaridades = await _dbConnection.QueryAsync<NivelEscolar>(sql);
            
            return escolaridades;
        }
    }
}