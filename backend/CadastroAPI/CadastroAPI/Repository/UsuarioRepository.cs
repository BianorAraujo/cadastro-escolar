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

        public async Task<int> Create(Usuario usuario)
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

            var id = await _dbConnection.ExecuteScalarAsync<int>(sql, parameters);

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
            const string sql = @"
                SELECT
                    u.IdUsuario,
                    u.Nome,
                    u.Sobrenome,
                    u.Email,
                    u.DataNascimento,
                    u.IdEscolaridade,
                    h.IdHistoricoEscolar,
                    h.Formato,
                    h.Nome
                FROM Usuario u
                LEFT JOIN UsuarioHistoricoEscolar uh 
                    ON u.IdUsuario = uh.IdUsuario
                LEFT JOIN HistoricoEscolar h
                    ON uh.IdHistoricoEscolar = h.IdHistoricoEscolar
                WHERE
                    u.IdUsuario = @id";

            Dictionary<int, Usuario> responseDictionary = new();

            var usuarios = await _dbConnection.QueryAsync<Usuario, HistoricoEscolar, Usuario>(
                sql,
                (usuario, historico) => 
                {
                    if(responseDictionary.TryGetValue(usuario.IdUsuario, out var existingUsuario))
                    {
                        usuario = existingUsuario;
                    }
                    else{
                        responseDictionary.Add(usuario.IdUsuario, usuario);
                    }

                    usuario.Historicos.Add(historico);

                    return usuario;
                },
                new {
                    id
                },
                splitOn: "IdHistoricoEscolar"
            );

            var usuarioResponse = responseDictionary[id];

            return usuarioResponse;
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
