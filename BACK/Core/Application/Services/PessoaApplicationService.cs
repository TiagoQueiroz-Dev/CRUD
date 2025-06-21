using Application.Interfaces;
using Application.ViewModels.PessoaViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Application.Services;

public class PessoaApplicationService : IPessoaApplicationService
{
    
    private readonly IPessoaService _pessoaService;
    private readonly IMapper _mapper;
    private readonly ILogger<PessoaApplicationService> _logger;

    public PessoaApplicationService(IPessoaService pessoaService, IMapper mapper, ILogger<PessoaApplicationService> logger)
    {
        _pessoaService = pessoaService;
        _mapper = mapper;
        _logger = logger;
    }

    public int Adicionar(AdicionarPessoaViewModel pPessoa)
    {
        var xPessoa = _mapper.Map<Pessoa>(pPessoa);
        var xRetorno = _pessoaService.Adicionar(xPessoa);
        _logger.LogInformation("Pessoa adicionada com sucesso");

       return xRetorno;
    }
    
}