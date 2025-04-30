using Aplication.Interfaces;
using Aplication.ViewModels.PessoaViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Services.Interfaces;

namespace Aplication.Services;

public class PessoaApplicationService : IPessoaApplicationService
{
    
    private readonly IPessoaService _pessoaService;
    private readonly IMapper _mapper;

    public PessoaApplicationService(IPessoaService pessoaService, IMapper mapper)
    {
        _pessoaService = pessoaService;
        _mapper = mapper;
    }

    public int Adicionar(AdicionarPessoaViewModel pPessoa)
    {
        var xPessoa = _mapper.Map<Pessoa>(pPessoa);
        
       var xRetorno = _pessoaService.Adicionar(xPessoa);
       
       return xRetorno;
    }
}