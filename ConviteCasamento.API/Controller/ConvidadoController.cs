using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConviteCasamento.API.Controller
{
    [ApiController]
    [Route("api/convidados")]
    public class ConvidadoController : ControllerBase
    {
        private readonly ILogger<ConvidadoController> _logger;
        private readonly IConvidadoService _service;

        public ConvidadoController(ILogger<ConvidadoController> logger, IConvidadoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("BuscarConvidado/{codigoAcesso}")]
        public async Task<IActionResult> BuscarConvidado(string codigoAcesso)
        {
            try
            {
                var convidado = await _service.BuscarConvidadoAsync(codigoAcesso);

                return Ok(convidado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar a requisição.");
                return StatusCode(500, new { Message = "Erro interno no servidor." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarPresenca([FromBody] ConvidadoViewModel convidadoVM)
        {
            try
            {
                await _service.ConfirmarPresencaAsync(convidadoVM);
                return Ok("Presença confirmada.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar a requisição.");
                return StatusCode(500, new { Message = "Erro interno no servidor." });
            }
        }
    }
}
