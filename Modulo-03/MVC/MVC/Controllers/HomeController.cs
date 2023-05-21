using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HomeController:Controller
    {

        public IActionResult Index() =>  Content("Home/Index (Default Controller & default View)");
    }
}
