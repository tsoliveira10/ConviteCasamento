using ConviteCasamento.API.ViewModels;

namespace ConviteCasamento.Application.Interfaces
{
    public interface IConvidadoService
    {
        Task<ConvidadoViewModel> BuscarConvidadoAsync(string codigoAcesso);

        Task ConfirmarPresencaAsync(ConvidadoViewModel model);
    }
}
