using _07_DEMO_anhadiendo_funcionalidades.Models.Entities;
using System;

namespace _07_DEMO_anhadiendo_funcionalidades.Models.Services
{
    public interface IBlogServices
    {
        IEnumerable<Post> GetLatestPosts(int max);
        IEnumerable<Post> GetPostByDate(int year, int month);

        Post GetPost(string slug);
    }
}
