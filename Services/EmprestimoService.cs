using SistemaBiblioteca.Backend.Data;
using SistemaBiblioteca.Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBiblioteca.Backend.Services
{
   public class EmprestimoService
{
    private readonly BibliotecaDbContext _context;

    public EmprestimoService(BibliotecaDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Emprestimo> GetEmprestimos()
    {
        return _context.Emprestimos.ToList();
    }

    public Emprestimo GetEmprestimoById(int id)
    {
        return _context.Emprestimos.FirstOrDefault(e => e.Id == id);
    }

    public Emprestimo RealizarEmprestimo(Emprestimo emprestimo)
    {
        _context.Emprestimos.Add(emprestimo);
        _context.SaveChanges();
        return emprestimo;
    }

    public void DevolverLivro(Emprestimo emprestimo)
    {
        _context.Emprestimos.Update(emprestimo);
        _context.SaveChanges();
    }

       public Emprestimo CreateEmprestimo(Emprestimo emprestimo)
    {
        _context.Emprestimos.Add(emprestimo);
        _context.SaveChanges();
        return emprestimo;
    }
}
}
