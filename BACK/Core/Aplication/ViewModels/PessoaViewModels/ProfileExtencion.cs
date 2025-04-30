using AutoMapper;
using Domain.Entities;

namespace Aplication.ViewModels.PessoaViewModels;

public class PessoaProfileExtencion : Profile
{
    public PessoaProfileExtencion()
    {
        CreateMap<AdicionarPessoaViewModel, Pessoa>()
            .ForMember(p => p.Nome, o => o.MapFrom(p => p.Nome))
            .ForMember(p => p.CriadoDataHora, p => p.MapFrom(pS => DateTime.UtcNow))
            .ReverseMap();
    } 
}