using SistemaBiblioteca.Backend.Data;
using SistemaBiblioteca.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBiblioteca.Backend.Services
{
    public class LivroService
    {
        private readonly BibliotecaDbContext _context;

        public LivroService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Livro> GetLivros()
        {
            return _context.Livros.ToList();
        }

        public Livro GetLivroById(int id)
        {
            return _context.Livros.FirstOrDefault(l => l.Id == id);
        }

        public Livro CreateLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return livro;
        }

        public void UpdateLivro(Livro livro)
        {
            livro.DataCadastro = DateTime.Now;
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }

        public void DeleteLivro(Livro livro)
        {
            _context.Livros.Remove(livro);
            _context.SaveChanges();
        }
    }
}
