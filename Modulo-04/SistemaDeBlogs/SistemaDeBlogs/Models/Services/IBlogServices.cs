using SistemaDeBlogs.Models.Entities;

namespace SistemaDeBlogs.Models.Services
{
    public interface IBlogServices
    {
        IEnumerable<Post> GetLatestPosts(int max);
        IEnumerable<Post> GetPostsByDate(int year, int month);
        Post GetPost(string slug);
    }
}
