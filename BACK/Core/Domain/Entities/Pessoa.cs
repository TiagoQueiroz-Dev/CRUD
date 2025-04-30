namespace Domain.Entities;

public class Pessoa
{
    public int Id { get; set; }
    public DateTime CriadoDataHora { get; set; }
    public bool Excluido { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public bool Genero { get; set; }
}