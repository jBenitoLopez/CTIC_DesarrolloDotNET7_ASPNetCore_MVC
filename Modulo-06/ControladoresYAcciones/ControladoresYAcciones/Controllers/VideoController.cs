using Microsoft.AspNetCore.Mvc;

namespace ControladoresYAcciones.Controllers
{
    public class VideoController : Controller
    {
        //https://localhost:7105/video/apagar
        [ActionName("apagar")]
        public IActionResult Shutdown()
        {
            return Content("El PC se esta Apagando!!!");
        }

        // solo disponible desde Postman x eje: https://localhost:7105/video/insert
        [HttpPost]
        public IActionResult Insert()
        {
            return Content("Nuevo registro Insertado...");
        }
    }
}
