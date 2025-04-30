using Domain.Entities;

namespace Domain.Repositories;

public interface IPessoaRepository
{
    int Adicionar(Pessoa pessoa);
}