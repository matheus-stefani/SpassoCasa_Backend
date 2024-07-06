using Microsoft.AspNetCore.Mvc;
using SpassoCasa_Backend.Context;
using SpassoCasa_Backend.ModelSemTabela;

namespace SpassoCasa_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly ApiDbContext _context;

        public LoginController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        public ActionResult Login(Login body)
        {
            var login = _context.Cadastros.
                     FirstOrDefault((e) => e.Email == body.Email && e.Senha == body.Senha);
            if (login is null) return BadRequest();

            return NoContent();
        }

    }
}
