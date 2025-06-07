using Domain.Interfaces;

namespace Domain.Enums;

public enum EGenero
{
     Masculino = 1,
     Feminino = 2
}

public class GeneroEnum : IEnumEntity
{
    public int Id { get; set; }
    public string Nome { get; set; }
}