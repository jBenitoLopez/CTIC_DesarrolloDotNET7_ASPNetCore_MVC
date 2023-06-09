using BindingAvanzado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BindingAvanzado.Controllers
{
    public class FriendsController:Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create01(Friend friend)
        {
            return Content($"Name = {friend.Name} \nAge = {friend.Age} \nEmail = {friend.Email}" +
                $"\nStreet = {friend.Address.Street} \nCity = {friend.Address.City}\n\n");
        }

        [HttpPost]
        public IActionResult Create([BindRequired]Friend friend)
        {

            if (!ModelState.IsValid) return Content("Error");
            

            return Content($"Name = {friend.Name} \nAge = {friend.Age} \nEmail = {friend.Email}" +
                $"\nStreet = {friend.Address.Street} \nCity = {friend.Address.City}\n\n");
        }
    }
}
