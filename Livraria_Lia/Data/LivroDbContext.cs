using Livraria_Lia.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria_Lia.Data
{
    public class LivroDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public virtual DbSet<Livro> Livros { get; set; }

        public LivroDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LivrariaDb"));
            }
        }

    }
}
