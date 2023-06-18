using DEMOApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DEMOApi.Controllers
{
    [Route("api/blog/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostsRepository postRepository;

        public PostsController(IPostsRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult All()
        {
            var posts = postRepository.All();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = postRepository.GetById(id);

            if(post == null) return NotFound();

            return Ok(post);    
        }

        [HttpPost]
        public IActionResult Create([FromBody] Post post)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid post");

            if (!postRepository.Create(post)) return Conflict();

            return CreatedAtAction("GetPost", new { id = post.Id, }, post);
        }

    }
}
