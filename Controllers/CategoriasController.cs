using Microsoft.AspNetCore.Mvc;
using SistemaBiblioteca.Backend.Models;
using SistemaBiblioteca.Backend.Services;
using System.Collections.Generic;

namespace SistemaBiblioteca.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriasController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            return Ok(_categoriaService.GetCategorias());
        }

        [HttpPost]
        public ActionResult<Categoria> CreateCategoria(Categoria categoria)
        {
            return Ok(_categoriaService.CreateCategoria(categoria));
        }

    }
}
