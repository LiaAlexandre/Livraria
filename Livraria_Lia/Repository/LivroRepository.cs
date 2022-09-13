using Livraria_Lia.Data;
using Livraria_Lia.Models;

namespace Livraria_Lia.Repository
{
    public class LivroRepository
    {
        LivroDbContext dbContext { get; set; }

        public LivroRepository()
        {
            dbContext = new LivroDbContext();
        }

        public List<Livro> Listar()
        {
            return dbContext.Livros.ToList();
        }

        public Livro BuscarPorId(int livroId)
        {
            return dbContext.Livros.SingleOrDefault(x => x.LivroId == livroId);
        }

        public void Salvar(Livro livro)
        {
            dbContext.Livros.Add(livro);

            dbContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var livroDb = dbContext.Livros.SingleOrDefault(x => x.LivroId == id);

            if (livroDb != null)
            {
                dbContext.Livros.Remove(livroDb);

                dbContext.SaveChanges();
            }
        }

        public void Atualizar(Livro livro)
        {
            var livroDb = dbContext.Livros.SingleOrDefault(x => x.LivroId == livro.LivroId);

            if (livroDb != null)
            {
                livroDb.Nome = livro.Nome;
                livroDb.Autor = livro.Autor;
                livroDb.Lido = livro.Lido;

                dbContext.SaveChanges();
            }
        }
    }
}
