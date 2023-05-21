using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controlers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return Content("Hola desde Home/Index");
        }
    }
}
