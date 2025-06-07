using Domain.Entities;
using Domain.Enums;
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

    public int Adicionar(Pessoa pPessoa)
    {
        
        if (string.IsNullOrWhiteSpace(pPessoa.Nome))
            throw new Exception("O nome é obrigatorio");

        if (pPessoa.DataNascimento.Equals(DateTime.MinValue))
            throw new Exception("Data de nascimento é obrigatorio");

        if (string.IsNullOrWhiteSpace(pPessoa.CPF))
            throw new Exception("CPF é obrigatorio");

        if (pPessoa.Genero != (int)EGenero.Masculino && pPessoa.Genero != (int)EGenero.Feminino)
            throw new Exception("Genero é obrigatorio");
        
        var xResultado = _pessoaRepository.Adicionar(pPessoa);
        
        return xResultado;
        
    }
}