using ConviteCasamento.Application.Model;
using ConviteCasamento.Domain.Entities;

namespace ConviteCasamento.API.ViewModels
{
    public class ConvidadoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IndicaAcompanhante { get; set; }
        public bool IndicaConfirmado { get; set; }
        public DateTime? DataConfirmacao { get; set; }
        public int? QuantidadeAcompanhantes { get; set; }
        public string CodigoAcesso { get; set; } // 🔹 Código único para acesso
        public AcompanhanteViewModel Acompanhante { get; set; } = new AcompanhanteViewModel();

        // Relacionamento
        public List<Acompanhante> Acompanhantes { get; set; } = new();
    }
}
