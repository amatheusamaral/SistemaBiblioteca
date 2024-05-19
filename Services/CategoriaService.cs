using SistemaBiblioteca.Backend.Data;
using SistemaBiblioteca.Backend.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBiblioteca.Backend.Services
{
    public class CategoriaService
    {
        private readonly BibliotecaDbContext _context;

        public CategoriaService(BibliotecaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Categoria CreateCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        // Outros métodos para CRUD de categorias
    }
}
