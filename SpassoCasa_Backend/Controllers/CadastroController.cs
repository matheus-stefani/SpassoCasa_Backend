using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SpassoCasa_Backend.Context;
using SpassoCasa_Backend.Migrations;
using SpassoCasa_Backend.Model;

namespace SpassoCasa_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CadastroController : ControllerBase
    {

        private readonly ApiDbContext _context;

        public CadastroController(ApiDbContext context) 
        {
            _context = context;
        }

        [HttpPost]

        public ActionResult UsuarioPost(Cadastro body)
        {
            _context.Add(body);
            _context.SaveChanges();

            return Created("/", body.CadastroId);
        }
    }
}
 