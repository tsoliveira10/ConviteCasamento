using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Application.Interfaces;
using ConviteCasamento.Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConviteCasamento.API.Controller
{
    [ApiController]
    [Route("api/convidados")]
    public class AcompanhanteController : ControllerBase
    {
        private readonly IAcompanhanteService _service;
        private readonly ILogger<ConvidadoController> _logger;

        public AcompanhanteController(IAcompanhanteService service, ILogger<ConvidadoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("AdicionarAcompanhante")]
        public async Task<IActionResult> AdicionarAcompanhante([FromBody] ConvidadoViewModel convidadoVM, [FromBody] AcompanhanteViewModel acompanhanteVM)
        {
            try
            {
                var acompanhante = await _service.AdicionarAcompanhanteAsync(convidadoVM, acompanhanteVM);
                return Ok(acompanhante);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[ERRO] {ex}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] ConvidadoViewModel convidadoVM)
        {
            try
            {
                var acompanhantes = await _service.GetAcompanhantesAsync(convidadoVM);
                return Ok(acompanhantes);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"[ERRO] {ex}");
                return BadRequest();
            }
        }
    }
}
