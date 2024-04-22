using Microsoft.AspNetCore.Mvc;
using SistemaUsuarios.Models;
using System.Diagnostics;

namespace SistemaUsuarios.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            HomeModel home = new HomeModel();
            home.Nome = "Cauã Micael";
            home.Email = "cauamicael@hotmail.com";

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
