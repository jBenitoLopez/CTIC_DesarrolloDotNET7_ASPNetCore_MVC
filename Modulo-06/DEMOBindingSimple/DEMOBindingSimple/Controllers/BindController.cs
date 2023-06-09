using Microsoft.AspNetCore.Mvc;

namespace DEMOBindingSimple.Controllers
{
    
    public class BindController:Controller
    {
        
        // https://localhost:7259/bind/test?i=10&b=false&s=Hola%20mundo!&d=3.14&array=11&array=12
        public IActionResult Test(int i, bool b, string s, double d, int[] array)
        {
            return Content($"i={i}, b={b}, s={s}, d={d}, i={string.Join(", ", array)}");
        }

        // https://localhost:7259/bind/test02/10
        // https://localhost:7259/bind/test02/666?i=10&b=false&s=Hola%20mundo!&d=3.14&array=11&array=12
        [Route("/bind/test2/{i}")]
        public IActionResult Test02(int i, bool b, string s, double d, int[] array)
        {
            return Content($"i={i}, b={b}, s={s}, d={d}, i={string.Join(", ", array)}");
        }
    }
}
