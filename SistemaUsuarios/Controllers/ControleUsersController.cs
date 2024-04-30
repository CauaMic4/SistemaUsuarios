using Microsoft.AspNetCore.Mvc;

namespace SistemaUsuarios.Controllers
{
    public class ControleUsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
