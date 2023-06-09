using DEMOValidaciones.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEMOValidaciones.Controllers
{
    public class FriendsController:Controller
    {
        public IActionResult Create() {
            return View(new Friend() { Name = "Pepito", Age = 33, Email = "pepito@mail.loc" });
        }

        [HttpPost]
        public IActionResult Create(Friend friend )
        {
            //if(!ModelState.IsValid) return Content("Not valid");
            if(!ModelState.IsValid) return View(friend);

            return Content($"Name = {friend.Name} \nAge = {friend.Age} \nEmail = {friend.Email} \n\n");
        }
    }
}
