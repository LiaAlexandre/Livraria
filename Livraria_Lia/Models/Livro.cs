namespace Livraria_Lia.Models
{
    public class Livro
    {
        public Livro()
        {
                
        }
        public int LivroId { get; set; }
        public string? Autor { get; set; }
        public string? Nome { get; set; }
        public bool Lido { get; set; }
    }
}
