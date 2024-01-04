using CadastroAPI.Entities;
using Dapper;
using System.Data;

namespace CadastroAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _dbConnection;

        public UsuarioRepository(IDbConnection dbConnection) 
        {
            _dbConnection = dbConnection;
        }

        public Task<int> Create(Usuario usuario)
        {
            var parameters = new {
                usuario.Nome,
                usuario.Sobrenome,
                usuario.Email,
                usuario.DataNascimento,
                usuario.IdEscolaridade
            };

            const string sql = @"
                INSERT INTO Usuario OUTPUT INSERTED.IdUsuario
                VALUES (@Nome, @Sobrenome, @Email, @DataNascimento, @IdEscolaridade)";

            var id = _dbConnection.ExecuteScalarAsync<int>(sql, parameters);

            return id;
        } 

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            const string sql = "SELECT * FROM Usuario";

            var usuarios = await _dbConnection.QueryAsync<Usuario>(sql);

            return usuarios;
        }

        public async Task<Usuario> GetById(int id)
        {
            var parameters = new { id };

            const string sql = @"
                SELECT * FROM Usuario
                WHERE IdUsuario = @id";

            var usuario = await _dbConnection.QuerySingleOrDefaultAsync<Usuario>(sql, parameters);

            return usuario;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            var parameters = new {
                usuario.IdUsuario,
                usuario.Nome,
                usuario.Sobrenome,
                usuario.Email,
                usuario.DataNascimento,
                usuario.IdEscolaridade
            };

            const string sql = @"
                UPDATE Usuario 
                SET Nome = @Nome, 
                    Sobrenome = @Sobrenome, 
                    Email = @Email, 
                    DataNascimento = @DataNascimento, 
                    IdEscolaridade = @IdEscolaridade 
                WHERE IdUsuario = @IdUsuario";

            var result = await _dbConnection.ExecuteAsync(sql, parameters);

            if(result != 1)
                return false;
            
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var parameters = new {
                id
            };

            const string sql = @"
                DELETE Usuario
                WHERE IdUsuario = @id";
            
            var result = await _dbConnection.ExecuteAsync(sql, parameters);

            if(result != 1)
                return false;
            
            return true;
        }
    }
}
