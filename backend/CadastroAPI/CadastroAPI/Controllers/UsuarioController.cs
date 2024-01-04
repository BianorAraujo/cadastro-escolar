using CadastroAPI.Entities;
using CadastroAPI.Models;
using CadastroAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<Usuario>>>> GetAll()
        {
            ServiceResponse<IEnumerable<Usuario>> response = new ServiceResponse<IEnumerable<Usuario>>();

            try
            {
                response.Dados = await _repository.GetAll();

                if (response.Dados == null)
                {
                    response.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Usuario>>> GetById(int id)
        {
            ServiceResponse<Usuario> response = new ServiceResponse<Usuario>();

            try
            {
                response.Dados = await _repository.GetById(id);
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> Create(Usuario model)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();

            try
            {
                //var usuario = new Usuario(model.Nome, model.Sobrenome, model.Email, model.DataNascimento, model.IdEscolaridade);

                response.Dados = await _repository.Create(model);
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Usuario>>> Update(Usuario model)
        {
            ServiceResponse<Usuario> response = new ServiceResponse<Usuario>();

            //var usuario = new Usuario(model.Nome, model.Sobrenome, model.Email, model.DataNascimento, model.IdEscolaridade);

            try
            {
                var result = await _repository.Update(model);
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<Usuario>>> Delete(int id)
        {
            ServiceResponse<Usuario> response = new ServiceResponse<Usuario>();

            try
            {
                var result = await _repository.Delete(id);
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Sucesso = false;
            }

            return Ok(response);
        }

    }
}
