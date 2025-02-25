using AutoMapper;
using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Application.Interfaces;
using ConviteCasamento.Application.Model;
using ConviteCasamento.Domain.Entities;
using ConviteCasamento.Domain.Interfaces;

namespace ConviteCasamento.Application.Services
{
    public class AcompanhanteService : IAcompanhanteService
    {
        private readonly IAcompanhanteRepository _repository;
        private readonly IMapper _mapper;

        public AcompanhanteService(IAcompanhanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AcompanhanteViewModel> AdicionarAcompanhanteAsync(ConvidadoViewModel convidadoVM, AcompanhanteViewModel acompanhanteVM)
        {
            if (acompanhanteVM == null) throw new Exception("Acompanhante não pode ser nulo.");
            if (convidadoVM == null) throw new Exception("Convidado não pode ser nulo.");
            if (convidadoVM.Id <= 0) throw new Exception("IdConvidado inválido");

            acompanhanteVM.IdConvidado = convidadoVM.Id;
            acompanhanteVM.IndicaConfirmado = true;

            var entity = _mapper.Map<Acompanhante>(acompanhanteVM);

            var acompanhante = await _repository.AdicionarAcompanhanteAsync(entity);
            return _mapper.Map<AcompanhanteViewModel>(acompanhante);
        }

        public async Task<List<AcompanhanteViewModel>> GetAcompanhantesAsync(ConvidadoViewModel convidadoVM)
        {
            if (convidadoVM == null) throw new Exception("Convidado não pode ser nulo");
            if (convidadoVM.Id <= 0) throw new Exception("Id do convidado não pode ser nulo");

            var acompanhantes = await _repository.GetByIdConvidadoAsync(convidadoVM.Id);
            var acompanhantesVM = _mapper.Map<List<AcompanhanteViewModel>>(acompanhantes);
            
            return acompanhantesVM;
        }
    }
}
