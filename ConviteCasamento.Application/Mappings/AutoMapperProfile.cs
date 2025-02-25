using AutoMapper;
using ConviteCasamento.API.ViewModels;
using ConviteCasamento.Application.Model;
using ConviteCasamento.Domain.Entities;

namespace ConviteCasamento.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Convidado, ConvidadoViewModel>().ReverseMap();
            CreateMap<Acompanhante,AcompanhanteViewModel>().ReverseMap();
            CreateMap<List<Convidado>, List<ConvidadoViewModel>>().ReverseMap();
            CreateMap<List<AcompanhanteViewModel>, List<Acompanhante>>().ReverseMap();
        }
    }
}
