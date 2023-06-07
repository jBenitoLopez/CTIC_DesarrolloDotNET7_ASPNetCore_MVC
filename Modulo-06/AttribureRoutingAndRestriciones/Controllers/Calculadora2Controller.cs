using Microsoft.AspNetCore.Mvc;

namespace AttribureRoutingAndRestriciones.Controllers
{
    //https://localhost:7074/calculadora2/mul/8
    [Route("[controller]/[action]/")]
    public class Calculadora2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //https://localhost:7074/calculadora2/sum/8/4
        [Route("{a:int}/{b:int}")]
        public IActionResult Sum(int a, int b)
        {
            return Content($"La suma de `{a}` y `{b}` es {a + b}");
        }

        //https://localhost:7074/calculadora2000/restar/8/4
        [Route("{a:int}/{b:int}")]
        public IActionResult Res(int a, int b)
        {
            return Content($"La Resta de `{a}` y `{b}` es {a - b}");
        }

        //https://localhost:7074/calculadora2/mul/8
        [Route("{a:int}/{b:int?}")]
        public IActionResult Mul(int a, int b = 1)
        {
            return Content($"La multiplicación de `{a}` y `{b}` es {a * b}");
        }

        //https://localhost:7074/calculadora2/div/8
        [Route("{a:int}/{b:int=1}")]
        public IActionResult Div(int a, int b)
        {
            return Content($"La división de `{a}` y `{b}` es {a / b}");
        }
    }
}
