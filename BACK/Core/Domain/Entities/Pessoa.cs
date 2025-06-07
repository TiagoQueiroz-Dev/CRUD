namespace Domain.Entities;

public class Pessoa : EntidadeBase
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public int Genero { get; set; }
}