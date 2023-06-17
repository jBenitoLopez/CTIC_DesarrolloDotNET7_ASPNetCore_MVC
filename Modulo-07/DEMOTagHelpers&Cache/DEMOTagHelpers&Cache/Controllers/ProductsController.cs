using Microsoft.AspNetCore.Mvc;

namespace DEMOTagHelpers_Cache.Controllers
{
    public class ProductsController : Controller
    {
        [Route("/products/{category}/{id}")]
        public IActionResult Show(int id, string category)
        {
            return Content($"Showing product {id} in category {category}");
        }
    }
}
