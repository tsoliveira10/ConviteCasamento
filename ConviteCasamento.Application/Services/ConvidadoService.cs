using AutoMapper;
using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Application.Interfaces;
using ConviteCasamento.Domain.Entities;

namespace ConviteCasamento.Application.Services
{
    public class ConvidadoService : IConvidadoService
    {
        private readonly IConvidadoRepository _repository;
        private readonly IMapper _mapper;

        public ConvidadoService(IConvidadoRepository convidadoRepository, IMapper mapper)
        {
            _repository = convidadoRepository;
            _mapper = mapper;
        }

        public async Task<ConvidadoViewModel> BuscarConvidadoAsync(string codigoAcesso)
        {
            if (string.IsNullOrEmpty(codigoAcesso)) 
                throw new ArgumentException("Código de acesso inválido.");

            var entity = await _repository.BuscarPorCodigoAcessoAsync(codigoAcesso) ?? 
                throw new KeyNotFoundException("Convidado não encontrado.");

            return _mapper.Map<ConvidadoViewModel>(entity);
        }

        public async Task ConfirmarPresencaAsync(ConvidadoViewModel model)
        {
            if (model == null) 
                throw new ArgumentException("Convidado não pode ser nulo.");

            if (model.Id <= 0)
                throw new ArgumentException("O Id do convidado é inválido");

            var convidadoEntity = await _repository.GetByIdAsync(model.Id)
                ?? throw new KeyNotFoundException("Convidado não encontrado.");

            if (convidadoEntity.IndicaConfirmado.HasValue)
                throw new InvalidOperationException("Convite já foi respondido e não pode ser alterado.");

            await _repository.UpdateConfirmacaoConvidadoAsync(model.Id, model.IndicaConfirmado);
        }
    }
}
