using CadastroAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly string _connectionString;

        public UsuarioController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnection");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var sqlConnectin = new SqlConnection(_connectionString))
            {
                const string sql = "SELECT * FROM Usuarios";

                var usuarios = await sqlConnectin.QueryAsync<UsuarioModel>(sql);

                return Ok(usuarios);
            }
        }
    }
}
