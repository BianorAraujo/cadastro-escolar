using CadastroAPI.Entities;
using CadastroAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI.Controllers
{
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    [Route("api/[controller]")]
    public class HistoricoController : Controller
    {
        private readonly IHistoricoRepository _repository;
        private const string PathDirectory = "Resources/Historicos";

        public HistoricoController(IHistoricoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Upload([FromForm] HistoricoFile historicoFile)
        {
            try
            {
                if (historicoFile.File != null && historicoFile.File.Length > 0)
                {
                    var file = historicoFile.File;
                    var idUsuario = historicoFile.Id;

                    var fileName = file.FileName;
                    var filePath = Path.Combine(PathDirectory, fileName);
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var extension = Path.GetExtension(file.FileName).Substring(1);

                    var historicoEscolar = new HistoricoEscolar(extension ,file.FileName.Split('.').First());

                    var idHistorico = await _repository.Create(historicoEscolar);

                    await _repository.CreateRelationship(idUsuario, idHistorico);
                    
                }
                
                return Ok();
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(File))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Download(int id)
        {
            try
            {
                var historicoEscolar = await _repository.GetById(id);

                var fileName = historicoEscolar.Nome + "." + historicoEscolar.Formato;

                var filePath = Path.Combine(PathDirectory, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    var fileBytes = System.IO.File.ReadAllBytes(filePath);
                    var contentType = "application/octet-stream";
                    
                    return File(fileBytes, contentType, fileName);
                }
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var historicoEscolar = await _repository.GetById(id);

                var fileName = historicoEscolar.Nome + "." + historicoEscolar.Formato;

                var filePath = Path.Combine(PathDirectory, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                    await _repository.DeleteRelationship(id);

                    await _repository.Delete(id);

                    return Ok();
                }
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}