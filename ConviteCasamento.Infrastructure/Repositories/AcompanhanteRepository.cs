using ConviteCasamento.Domain.Entities;
using ConviteCasamento.Domain.Interfaces;
using ConviteCasamento.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ConviteCasamento.Infrastructure.Repositories
{
    public class AcompanhanteRepository : IAcompanhanteRepository
    {
        private readonly ApplicationDbContext _context;

        public AcompanhanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Acompanhante> AdicionarAcompanhanteAsync(Acompanhante entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Acompanhante>> GetByIdConvidadoAsync(int id)
        {
            return await _context.Acompanhantes.Where(x => x.IdConvidado == id).ToListAsync();
        }
    }
}
