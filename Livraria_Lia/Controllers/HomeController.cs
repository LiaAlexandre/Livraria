using Livraria_Lia.Models;
using Livraria_Lia.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Livraria_Lia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        LivroRepository livroRepository { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            livroRepository = new LivroRepository();
        }

        public IActionResult Index()
        {
            List<Livro> livros = new List<Livro>();

            try
            {
                livros = livroRepository.Listar();
                //por que não está funcionando o thenBy?
                livros = livros.OrderBy(livro => livro.Autor).ThenBy(livro => livro.Nome).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar os livros.");
            }

            return View(livros);
        }

        public ActionResult Adicionar()
        {
            try
            {
                return View("Adicionar");
            }
            catch
            {
                throw new Exception("Erro ao carregar a tela de adicionar livro.");
            }

        }

        public ActionResult Salvar(Livro livro)
        {
            try
            {
                livroRepository.Salvar(livro);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao salvar livro.");
            }

            return RedirectToAction("Index");
        }
        public ActionResult EditarGet(int livroId)
        {
            Livro livro = new();
            try
            {
                livro = livroRepository.BuscarPorId(livroId);
            }
            catch(Exception)
            {
                throw new Exception("Erro ao carregar tela de edição.");
            }
            return View("Editar", livro);
        }

        public ActionResult Editar(Livro livro)
        {
            try
            {
                livroRepository.Atualizar(livro);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao editar livro.");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int livroId)
        {
            try
            {
                livroRepository.Excluir(livroId);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao excluir livro.");
            }

            return RedirectToAction("Index");
        }
    }
}