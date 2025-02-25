using ConviteCasamento.Application.Model;
using ConviteCasamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConviteCasamento.Domain.Interfaces
{
    public interface IAcompanhanteRepository
    {
        Task<Acompanhante> AdicionarAcompanhanteAsync(Acompanhante entity);
        Task<List<Acompanhante>> GetByIdConvidadoAsync(int id);
    }
}
