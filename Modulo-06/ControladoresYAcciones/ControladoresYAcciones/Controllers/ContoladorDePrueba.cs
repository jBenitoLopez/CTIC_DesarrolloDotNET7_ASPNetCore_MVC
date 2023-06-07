using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControladoresYAcciones.Controllers
{
    [Controller]
    public class ContoladorDePrueba
    {
        //https://localhost:7105/SayHello/Pepito
        [Route("/sayhello/{name}")]
        public ActionResult SayHello(string name)
        {
            return new ContentResult()
            {
                Content = $"Hello {name}!"
            };
        }

        // https://localhost:7105/ContoladorDePrueba/SayBye?name=Pepito
        public ActionResult SayBye(string name)
        {
            return new ContentResult()
            {
                Content = $"Adios {name}!"
            };
        }
    }
}
