using SistemaDeBlogs.Models.Entities;
using SistemaDeBlogs.Models.Services;

namespace SistemaDeBlogs.Services
{
    public class BlogServices : IBlogServices
    {
        // Repositorio en memoria
        private static readonly List<Post> Posts;

        // Poblado inicial de datos
        static BlogServices()
        {
            Posts = new List<Post>
            {
                new Post() {Title = "Welcome to MVC", Slug = "welcome-to-mvc",
                            Author = "jmaguilar", Text = "Hi! Welcome to MVC!",
                            Date = new DateTime(2016, 01, 01)},
                new Post() {Title = "Second post", Slug = "second-post",
                            Author = "jmaguilar", Text = "Hello, this is my second post :)",
                            Date = new DateTime(2016, 01, 10)},
                new Post() {Title = "Another post", Slug = "another-post",
                            Author = "jmaguilar", Text = "Wow, this is my third post!",
                            Date = new DateTime(2016, 03, 15)},
            };

            for (int i = 1; i < 5; i++)
            {
                Posts.Add(
                    new Post() { Title = $"Post number {i}", Slug = $"Post-number-{i}",
                        Author = "jmaguilar", Text = $"Text of post #{i}",
                        Date = new DateTime(2016, 06, 01).AddDays(i)}
                );
            }
        }

        // Miembros de IBlogServices:
        public IEnumerable<Post> GetLatestPosts(int max)
        {
            var posts = from post in Posts
                        orderby post.Date descending
                        select post;
            return posts.Take(max).ToList();
        }

        public IEnumerable<Post> GetPostsByDate(int year, int month)
        {
            var posts = from post in Posts
                        where post.Date.Month == month && post.Date.Year == year
                        orderby post.Date descending
                        select post;
            return posts.ToList();
        }

        public Post GetPost(string slug)
        {
            return Posts.FirstOrDefault(
                post => post.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase)
            );
        }

    }
}
