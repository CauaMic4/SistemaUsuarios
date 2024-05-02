using Microsoft.AspNetCore.Mvc;
using SistemaUsuarios.Models;
using SistemaUsuarios.Repositorio;

namespace SistemaUsuarios.Controllers
{
    public class ControleUsersController : Controller
    {
        private readonly IControleUserRepositorio _controleUserRepositorio;
        public ControleUsersController(IControleUserRepositorio controleUserRepositorio)
        {
            _controleUserRepositorio = controleUserRepositorio;
        }

        public IActionResult Index()
        {
            List<ControleUsersModel> controleUsers = _controleUserRepositorio.BuscarTodos();

            return View(controleUsers);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ControleUsersModel controleUsers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _controleUserRepositorio.Adicionar(controleUsers);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View(controleUsers);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Algo deu errado! Detalhe do erro: {erro.Message}";

                return RedirectToAction("Index");
            }

        }

    }
}
