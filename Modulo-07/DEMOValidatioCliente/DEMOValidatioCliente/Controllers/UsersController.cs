using DEMOValidatioCliente.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DEMOValidatioCliente.Controllers
{
    public class UsersController : Controller
    {
        // https://localhost:7057/users/create
        public IActionResult Create()
        {
            return View(new CreateUserViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            // TODO: Salvar los datos del usuario

            return Content("OK");
        }
    }
}
