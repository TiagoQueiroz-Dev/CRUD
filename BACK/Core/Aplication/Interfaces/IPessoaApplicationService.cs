using Aplication.ViewModels.PessoaViewModels;
using Domain.Entities;

namespace Aplication.Interfaces;

public interface IPessoaApplicationService
{
    int Adicionar(AdicionarPessoaViewModel Pessoa);
}