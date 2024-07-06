using Microsoft.EntityFrameworkCore;
using SpassoCasa_Backend.Model;

namespace SpassoCasa_Backend.Context
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {}

        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
    }
}
