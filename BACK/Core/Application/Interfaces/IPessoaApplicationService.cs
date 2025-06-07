using Application.ViewModels.PessoaViewModels;
using Domain.Entities;

namespace Application.Interfaces;

public interface IPessoaApplicationService
{
    int Adicionar(AdicionarPessoaViewModel Pessoa);
}