using CadastroAPI.Entities;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usuarios = await _repository.GetAll();

                if (usuarios != null)
                    return Ok(usuarios);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Usuario model)
        {
            try
            {
                var id = await _repository.Create(model);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuarios = await _repository.GetById(id);

                if (usuarios != null)
                    return Ok(usuarios);
                else
                    return NotFound();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Usuario model)
        {
            try
            {
                var result = await _repository.Update(model);

                if(result)
                    return Ok();
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _repository.Delete(id);

                if(result)
                    return Ok();
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
