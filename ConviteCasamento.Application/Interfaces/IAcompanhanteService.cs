using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Application.Model;

namespace ConviteCasamento.Application.Interfaces
{
    public interface IAcompanhanteService
    {
        Task<AcompanhanteViewModel> AdicionarAcompanhanteAsync(ConvidadoViewModel convidadoVM, AcompanhanteViewModel acompanhanteVM);

        Task<List<AcompanhanteViewModel>> GetAcompanhantesAsync(ConvidadoViewModel convidadoVM);
    }
}
