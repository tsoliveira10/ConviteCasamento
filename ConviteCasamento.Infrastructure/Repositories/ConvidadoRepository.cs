using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Application.Interfaces;
using ConviteCasamento.Domain.Entities;
using ConviteCasamento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ConviteCasamento.Infrastructure.Repositories
{
    public class ConvidadoRepository : IConvidadoRepository
    {
        private readonly ApplicationDbContext _context;

        public ConvidadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Convidado> BuscarPorCodigoAcessoAsync(string codigoAcesso)
        {
            return await _context.Convidados
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CodigoAcesso == codigoAcesso);
        }

        public async Task UpdateConfirmacaoConvidadoAsync(int id, bool indicaConfirmado)
        {
            await _context.Convidados
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(setters => setters.SetProperty(c => c.IndicaConfirmado, indicaConfirmado));
        }

        public async Task<Convidado> GetByIdAsync (int id)
        {
            return await _context.Convidados
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
