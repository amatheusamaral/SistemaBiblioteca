using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Backend.Models;
using SistemaBiblioteca.Backend.Services;
using System.Collections.Generic;
using System;

namespace SistemaBiblioteca.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly EmprestimoService _emprestimoService;

        public EmprestimosController(EmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Emprestimo>> GetEmprestimos()
        {
            return Ok(_emprestimoService.GetEmprestimos());
        }

        [HttpPost]
        public ActionResult<Emprestimo> CreateEmprestimo(Emprestimo emprestimo)
        {
            return Ok(_emprestimoService.CreateEmprestimo(emprestimo));
        }

        [HttpPost]
        public ActionResult<Emprestimo> RealizarEmprestimo(Emprestimo emprestimo)
        {
            // Lógica para realizar um empréstimo de livro
            emprestimo.DataEmprestimo = DateTime.Now;
            _emprestimoService.RealizarEmprestimo(emprestimo);
            return Ok(emprestimo);
        }

        [HttpPost("devolucao/{id}")]
        public IActionResult DevolverLivro(int id)
        {
            var emprestimo = _emprestimoService.GetEmprestimoById(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            // Lógica para devolver um livro
            emprestimo.DataDevolucao = DateTime.Now;
            _emprestimoService.DevolverLivro(emprestimo);
            return NoContent();
        }

        // Outros métodos para CRUD de empréstimos
    }
}
