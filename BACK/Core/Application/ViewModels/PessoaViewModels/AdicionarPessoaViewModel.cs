using AutoMapper;
using Domain.Entities;

namespace Application.ViewModels.PessoaViewModels;

public class AdicionarPessoaViewModel 
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Genero { get; set; }
}