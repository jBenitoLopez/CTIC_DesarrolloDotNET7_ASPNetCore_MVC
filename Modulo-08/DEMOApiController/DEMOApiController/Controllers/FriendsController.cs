using DEMOApiController.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DEMOApiController.Controllers
{
    [ApiController]
    public class FriendsController : ControllerBase
    {
        [HttpPost("/friends/create")]
        public ActionResult<Friend> Create(Friend f)
        {
            if (!ModelState.IsValid) return BadRequest();

            return f;
        }
    }
}
