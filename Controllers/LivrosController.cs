using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Backend.Models;
using SistemaBiblioteca.Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBiblioteca.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly LivroService _livroService;
        private readonly EmprestimoService _emprestimoService;

        public LivrosController(LivroService livroService, EmprestimoService emprestimoService)
        {
            _livroService = livroService;
            _emprestimoService = emprestimoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> GetLivros()
        {
            return Ok(_livroService.GetLivros());
        }

        [HttpGet("disponiveis")]
        public ActionResult<IEnumerable<Livro>> GetLivrosDisponiveis()
        {
            var livrosDisponiveis = _livroService.GetLivros().Where(l => !_emprestimoService.GetEmprestimos().Any(e => e.LivroId == l.Id && e.DataDevolucao == null));
            return Ok(livrosDisponiveis);
        }

        [HttpPost]
        public ActionResult<Livro> CreateLivro(Livro livro)
        {
            livro.DataCadastro = DateTime.Now;
            return Ok(_livroService.CreateLivro(livro));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLivro(int id, Livro livro)
        {
            var livroToUpdate = _livroService.GetLivroById(id);
            if (livroToUpdate == null)
            {
                return NotFound();
            }

            livroToUpdate.Titulo = livro.Titulo;
            livroToUpdate.Autor = livro.Autor;
            livroToUpdate.Categoria = livro.Categoria;

            _livroService.UpdateLivro(livroToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLivro(int id)
        {
            var livroToDelete = _livroService.GetLivroById(id);
            if (livroToDelete == null)
            {
                return NotFound();
            }

            _livroService.DeleteLivro(livroToDelete);
            return NoContent();
        }
    }
}
