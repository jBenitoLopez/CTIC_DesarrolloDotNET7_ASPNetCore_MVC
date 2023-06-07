using Microsoft.AspNetCore.Mvc;

namespace AttribureRoutingAndRestriciones.Controllers
{
    public class Calculadora0Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // https://localhost:7074/Calculadora0/Sum?a=5&b=7
        public IActionResult Sum(int a, int b)
        {
            return Content($"La suma de `{a}` y `{b}` es {a+b}");
        }
    }
}
