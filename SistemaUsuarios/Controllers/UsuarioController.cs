using Microsoft.AspNetCore.Mvc;
using SistemaUsuarios.Models;
using SistemaUsuarios.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaUsuarios.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);

            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Apagar(id);
                    TempData["MensagemSucesso"] = "Usuario deletado com sucesso!";

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Algo deu errado! Detalhe do erro: {erro.Message}";

                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Algo deu errado! Detalhe do erro: {erro.Message}";

                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario editado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View("Editar", usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Algo deu errado! Detalhe do erro: {erro.Message}";

                return RedirectToAction("Index");
            }
        }


    }
}
