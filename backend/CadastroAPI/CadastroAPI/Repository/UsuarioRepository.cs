using CadastroAPI.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CadastroAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioRepository(IDbConnection dbConnection) 
        {
            _dbConnection = dbConnection;
        } 

        public void Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            const string sql = "SELECT * FROM Usuario";

            var usuarios = _dbConnection.Query<Usuario>(sql);

            return usuarios;
        }

        public int Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
