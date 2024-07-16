
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpassoCasa_Backend.Model;
using SpassoCasa_Backend.Model.JWT;

namespace SpassoCasa_Backend.Context
{
    public class ApiDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {}

        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
