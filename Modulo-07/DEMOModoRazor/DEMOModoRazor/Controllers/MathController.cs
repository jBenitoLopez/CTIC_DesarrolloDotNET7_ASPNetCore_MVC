using Microsoft.AspNetCore.Mvc;
using System;

namespace DEMOModoRazor.Controllers
{
    public class MathController : Controller
    {
        // https://localhost:7201/math/mul/22
        [Route("/math/mul/{n}")]
        public IActionResult Multiplicacion(int n)
        {
            return View(n);
        }
    }
}
