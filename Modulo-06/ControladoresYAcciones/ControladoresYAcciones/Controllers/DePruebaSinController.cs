using Microsoft.AspNetCore.Mvc;

namespace ControladoresYAcciones.Controllers
{
    // no hereda de Controll
    //[NonController]
    public class DePruebaSinController
    {
        // no entra: https://localhost:7105/DePruebaSin/Privado
        [NonAction]
        public IActionResult Privado()
        {
            return new ContentResult() { 
                Content = $"Esto es un SECRETO !!!"
            };
        }

        // https://localhost:7105/DePruebaSin/Publico
        public IActionResult Publico()
        {
            return new ContentResult()
            {
                Content = $"Acceso para todos :)"
            };
        }
    }
}
