using Livraria_Lia.Models;
using Livraria_Lia.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Livraria_Lia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _configuration;

        LivroRepository livroRepository { get; set; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            livroRepository = new LivroRepository(configuration);
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
                return View("Error");
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
                return View("Error");
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
                return View("Error");
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
                return View("Error");
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
                return View("Error");
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
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}