using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Backend.Models;

namespace SistemaBiblioteca.Backend.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
                .Property(l => l.Titulo)
                .IsRequired();

            modelBuilder.Entity<Livro>()
                .Property(l => l.Autor)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
