using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Domain.Entities;

namespace ConviteCasamento.Application.Interfaces
{
    public interface IConvidadoRepository
    {
        Task UpdateConfirmacaoConvidadoAsync(int id, bool indicaConfirmado);

        Task<Convidado> BuscarPorCodigoAcessoAsync(string codigoAcesso);

        Task<Convidado> GetByIdAsync(int id);
    }
}
