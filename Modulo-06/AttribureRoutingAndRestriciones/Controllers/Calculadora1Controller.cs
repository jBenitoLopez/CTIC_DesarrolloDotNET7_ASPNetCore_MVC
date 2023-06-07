using Microsoft.AspNetCore.Mvc;

namespace AttribureRoutingAndRestriciones.Controllers
{
    public class Calculadora1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //https://localhost:7074/calculadora1/sum/8/4
        [Route("calculadora1/sum/{a}/{b}")]
        public IActionResult Sum(int a, int b)
        {
            return Content($"La suma de `{a}` y `{b}` es {a + b}");
        }

        //https://localhost:7074/calculadora1000/restar/8/4
        [Route("calculadora1000/restar/{a}/{b}")]
        public IActionResult Res(int a, int b)
        {
            return Content($"La Resta de `{a}` y `{b}` es {a - b}");
        }

        //https://localhost:7074/calculadora1/mul/8
        [Route("[controller]/[action]/{a}/{b?}")]
        public IActionResult Mul(int a, int b = 1)
        {
            return Content($"La multiplicación de `{a}` y `{b}` es {a * b}");
        }

        //https://localhost:7074/calculadora1/div/8
        [Route("[controller]/[action]/{a}/{b=1}")]
        public IActionResult Div(int a, int b)
        {
            return Content($"La división de `{a}` y `{b}` es {a / b}");
        }
    }
}
