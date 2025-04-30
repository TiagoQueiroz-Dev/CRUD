using AutoMapper;
using Domain.Entities;

namespace Aplication.ViewModels.PessoaViewModels;

public class AdicionarPessoaViewModel 
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Genero { get; set; }
}