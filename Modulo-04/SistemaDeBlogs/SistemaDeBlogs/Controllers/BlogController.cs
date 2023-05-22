using Microsoft.AspNetCore.Mvc;
using SistemaDeBlogs.Models.Services;
using SistemaDeBlogs.Services;

namespace SistemaDeBlogs.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogServices blogServices;

        public BlogController(IBlogServices blogServices)
        {
            this.blogServices = blogServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Index()
        //{
        //    var posts = blogServices.GetLatestPosts(10); // 10 posts más recientes
        //    return View(posts); // "Index" por defecto
        //}

        public IActionResult Index()
        {
            var posts = blogServices.GetLatestPosts(10); // 10 posts más recientes
            return View("Index", posts);
        }

        public IActionResult Archive(int year, int month)
        {
            var posts = blogServices.GetPostsByDate(year, month);
            return View(posts);
        }

        [Route("blog/{slug}")]
        public IActionResult ViewPost(string slug)
        {
            var post = blogServices.GetPost(slug);

            if (post == null) return NotFound();
  
            return View(post);
        }


    }
}
