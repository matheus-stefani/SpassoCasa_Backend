using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpassoCasa_Backend.Context;
using SpassoCasa_Backend.Model;

namespace SpassoCasa_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ProdutosController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        //[Authorize]
        public IActionResult AdicionarProduto(Produtos body)
        {
            _context.Produtos.Add(body);
            _context.SaveChanges();

            return Created("", body.ProdutoId);
        }

        [HttpGet]

        public ActionResult<IEnumerable<Produtos>> PegarProduto()
        {
            var produtos = _context.Produtos.ToList();

            if (produtos is null) return NotFound("Banco de dados Vazio");

            return produtos;
        }

        [HttpGet("{id}")]

        public ActionResult<Produtos> PegarProdutoPeloId(int id)
        {
            var pegarProduto = _context.Produtos.FirstOrDefault((e)=> e.ProdutoId == id);

            if (pegarProduto is null) return NotFound("Id não existe no banco de dados");

            return pegarProduto;
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(int id)
        {
            var pegarProduto = _context.Produtos.FirstOrDefault((e)=> e.ProdutoId == id);

            if (pegarProduto is null) return NotFound("Produto não existe no banco de dados");

            _context.Produtos.Remove(pegarProduto);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        //[Authorize]
        public ActionResult Put(int id, Produtos produtos)
        {
            if (id != produtos.ProdutoId) return BadRequest();

            _context.Entry(produtos).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

    }
}
