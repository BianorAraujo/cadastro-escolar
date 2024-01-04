using CadastroAPI.Entities;
using CadastroAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    [Route("api/[controller]")]
    public class EscolaridadeController : Controller
    {
        private readonly IEscolaridadeRepository _repository;

        public EscolaridadeController(IEscolaridadeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NivelEscolar))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var escolaridades = await _repository.GetAll();

                if (escolaridades.Count() > 0)
                    return Ok(escolaridades);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}