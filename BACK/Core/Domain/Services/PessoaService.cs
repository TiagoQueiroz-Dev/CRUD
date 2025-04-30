using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services;

public class PessoaService : IPessoaService
{
   private readonly IPessoaRepository _pessoaRepository;

    public PessoaService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public int Adicionar(Pessoa pessoa)
    {
        var xResultado = _pessoaRepository.Adicionar(pessoa);
        
        return xResultado;
        
    }
}