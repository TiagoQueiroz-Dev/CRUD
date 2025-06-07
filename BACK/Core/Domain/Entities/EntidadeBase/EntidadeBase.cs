namespace Domain.Entities;

public class EntidadeBase
{
    public int Id { get; set; }
    public bool Excluido { get; set; }
    public DateTime CriadoDataHora { get; set; } = DateTime.UtcNow;
}