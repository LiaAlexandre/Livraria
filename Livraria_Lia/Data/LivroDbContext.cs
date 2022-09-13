using Livraria_Lia.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria_Lia.Data
{
    public class LivroDbContext : DbContext
    {
        public virtual DbSet<Livro> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=LAPTOP-FGQM066T;Database=Livraria_Lia;Trusted_Connection=True;");
            }
        }

    }
}
