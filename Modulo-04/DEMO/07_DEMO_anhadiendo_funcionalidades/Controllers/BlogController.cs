using _07_DEMO_anhadiendo_funcionalidades.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace _07_DEMO_anhadiendo_funcionalidades.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogServices blogServices;

        public BlogController(IBlogServices blogServices)
        {
            this.blogServices = blogServices;
        }
        public IActionResult Index()
        {
            var posts = blogServices.GetLatestPosts(10);
            return View(posts);
        }
        public IActionResult Archive(int year, int month)
        {
            var posts = blogServices.GetPostByDate(year, month);
            return View(posts);
        }

        [Route("blog/{slug}")]
        public IActionResult ViewPost(string slug)
        {
            var posts = blogServices.GetPost(slug);

            if (posts == null) return NotFound();

            return View(posts);
        }
    }
}
