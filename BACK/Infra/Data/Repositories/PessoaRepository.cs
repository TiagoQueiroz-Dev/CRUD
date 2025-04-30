using Data.DataContext;
using Domain.Entities;
using Domain.Repositories;


namespace Data.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly Context _context;

    public PessoaRepository(Context context)
    {
        _context = context;
    }

    public int Adicionar(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        _context.SaveChanges();
        
        return pessoa.Id;
    }
}