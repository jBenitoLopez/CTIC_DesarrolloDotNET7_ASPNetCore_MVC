using DEMOValidatioCliente.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DEMOValidatioCliente.Controllers
{
    public class UsersController : Controller
    {
        // https://localhost:7057/users/create
        public IActionResult Create()
        {
            return View(new CreateUserViewModel() { Username = "Pepito", FullName = "Pepito Grillo", Email = "pepito@mail.loc", Password = "asdfasdf", RePassword = "asdfasdf", Enabled = true });
        }

        [HttpPost]
        public IActionResult Create(CreateUserViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            // TODO: Salvar los datos del usuario

            return View("Details", vm);
        }

        public IActionResult Details(CreateUserViewModel vm)
        {
            return View(vm);
        }
    }
}
