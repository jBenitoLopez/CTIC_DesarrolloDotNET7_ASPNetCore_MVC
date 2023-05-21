using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class TestController : Controller
    {

        // Ruta por defecto: {controler}/{action}/{id?}

        public IActionResult Index()
        {
            return Content("Hello from INDEX");
        }


        // GET: https://localhost:7077/test/hello/jhon?age=33
        public IActionResult Hello(string id, int age)
        {
            var name = id ?? "name";
            return Content($"Hello, {name}! You are {age} years old.");
        }
    }
}
