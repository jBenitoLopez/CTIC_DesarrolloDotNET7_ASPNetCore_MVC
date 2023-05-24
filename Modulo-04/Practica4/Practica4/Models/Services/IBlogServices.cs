using Practica4.Models.Entities;

namespace Practica4.Models.Services
{
    public interface IBlogServices
    {
        IEnumerable<Post> GetLatestPosts(int max);
        IEnumerable<Post> GetPostsByDate(int year, int month);
        Post GetPost(string slug);
    }
}
