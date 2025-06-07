using AutoMapper;
using Domain.Entities;

namespace Application.ViewModels.PessoaViewModels;

public class PessoaProfileExtencion : Profile
{
    public PessoaProfileExtencion()
    {
        CreateMap<AdicionarPessoaViewModel, Pessoa>()
            .ForMember(p => p.Nome, o => o.MapFrom(p => p.Nome))
            .ForMember(p => p.DataNascimento, p => p.MapFrom(pS => pS.DataNascimento))
            .ForMember(p => p.CPF, p => p.MapFrom(pS => pS.CPF))
            .ForMember(p => p.Genero, p => p.MapFrom(pS => pS.Genero))
            .ReverseMap();
    } 
}