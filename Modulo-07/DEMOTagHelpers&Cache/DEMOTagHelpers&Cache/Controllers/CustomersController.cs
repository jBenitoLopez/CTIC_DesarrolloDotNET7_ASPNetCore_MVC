using DEMOTagHelpers_Cache.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DEMOTagHelpers_Cache.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Create()
        {
            return View(new CreateCustomerViewModel());
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            return Content("Procuct created");

        }
    }
}
